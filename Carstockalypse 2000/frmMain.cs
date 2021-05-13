using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;

using ToxicRagers.Carmageddon.Formats;
using ToxicRagers.Carmageddon.Helpers;
using ToxicRagers.Carmageddon2.Formats;
using OpponentTXT = ToxicRagers.Carmageddon2.Formats.OpponentTXT;
using OpponentDetails = ToxicRagers.Carmageddon2.Formats.OpponentDetails;

namespace Carstockalypse_2000
{
    public partial class frmMain : Form
    {
        string path;
        OpponentTXT opponents;
        readonly List<OpponentDetails> mods = new List<OpponentDetails>();
        readonly Dictionary<int, string> modZips = new Dictionary<int, string>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblVersion.Text = $"v{Application.ProductVersion}";

            reloadUI();
        }

        private void lstAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAvailable.SelectedIndex >= 0)
            {
                btnInstall.Enabled = true;

                loadDetails(mods[lstAvailable.SelectedIndex], "Available", lstAvailable.SelectedIndex);
            }
        }

        private void lstInstalled_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstInstalled.SelectedIndex >= 0)
            {
                btnUninstall.Enabled = true;

                btnUp.Enabled = lstInstalled.SelectedIndex > 0;
                btnDown.Enabled = lstInstalled.SelectedIndex + 1 < opponents.Opponents.Count;

                loadDetails(opponents.Opponents[lstInstalled.SelectedIndex], "Installed");
            }
        }

        private void loadDetails(OpponentDetails opponent, string panel, int index = -1)
        {
            string carName = Path.GetFileNameWithoutExtension(opponent.CarFilename);

            (Controls.Find($"txt{panel}Description", true)[0] as TextBox).Text = $"Driver: {opponent.DriverName}\r\nCar: {opponent.CarName}\r\nStrength: {opponent.StrengthRating}\r\nCost: {opponent.CostToBuy}\r\nNetwork Availability: {opponent.NetworkAvailability}\r\n{opponent.TopSpeed}\r\n{opponent.KerbWeight}\r\n{opponent.To60}";

            Bitmap carImage = new Bitmap(192, 128);

            using (Graphics g = Graphics.FromImage(carImage))
            {
                g.DrawImage(getBitmap(carName, "A", index), 0, 0);
                g.DrawImage(getBitmap(carName, "B", index), 64, 0);
                g.DrawImage(getBitmap(carName, "C", index), 128, 0);
                g.DrawImage(getBitmap(carName, "D", index), 0, 64);
                g.DrawImage(getBitmap(carName, "E", index), 64, 64);
                g.DrawImage(getBitmap(carName, "F", index), 128, 64);
            }

            (Controls.Find($"pb{panel}", true)[0] as PictureBox).Image = carImage;
        }

        private Bitmap getBitmap(string carName, string letter, int index)
        {
            string filename = $"{carName}{letter}";

            if (index > -1 && modZips.ContainsKey(index))
            {
                using (FileStream fs = new FileStream(modZips[index], FileMode.Open))
                using (ZipArchive archive = new ZipArchive(fs, ZipArchiveMode.Read))
                {
                    ZipArchiveEntry entry;

                    entry = archive.Entries.FirstOrDefault(f => string.Compare(f.Name, $"{filename}.tif", true) == 0);

                    if (entry != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            entry.Open().CopyTo(ms);
                            ms.Seek(0, SeekOrigin.Begin);

                            return new Bitmap((Bitmap)Image.FromStream(ms));
                        }
                    }

                    entry = archive.Entries.FirstOrDefault(f => string.Compare(f.Name, $"{filename}.pix", true) == 0 && f.FullName.ToLower().Contains("pix16"));

                    if (entry != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            entry.Open().CopyTo(ms);
                            ms.Seek(0, SeekOrigin.Begin);

                            PIX pix = PIX.Load(ms);

                            if (pix is null) { return new Bitmap(64, 64); }

                            pix.Pixies[0].Format = PIXIE.PixelmapFormat.C2_16bitAlpha;
                            return pix.Pixies[0].GetBitmap();
                        }
                    }

                    entry = archive.Entries.FirstOrDefault(f => string.Compare(f.Name, $"{carName}CI.twt", true) == 0);

                    if (entry != null)
                    {
                        // twt in a zip will contain pixies
                        using (MemoryStream ms = new MemoryStream())
                        {
                            entry.Open().CopyTo(ms);
                            ms.Seek(0, SeekOrigin.Begin);

                            TWT twt = TWT.Load(ms);
                            TWTEntry twtEntry = twt.Contents.FirstOrDefault(c => string.Compare(c.Name, "pixies.p16", true) == 0);

                            if (twtEntry != null)
                            {
                                using (MemoryStream msTWT = new MemoryStream(twt.Extract(twtEntry)))
                                {
                                    PIX pix = PIX.Load(msTWT);

                                    PIXIE pixie = pix.Pixies.First(p => string.Compare(p.Name, $"{filename}", true) == 0);
                                    pixie.Format = PIXIE.PixelmapFormat.C2_16bitAlpha;
                                    return pixie.GetBitmap();
                                }
                            }
                        }
                    }
                }
            }

            if (Directory.Exists(Path.Combine(path, "data", "intrface", "carimage", $"{carName}CI")))
            {
                if (Directory.Exists(Path.Combine(path, "data", "intrface", "carimage", $"{carName}CI", "tiffrgb")))
                {
                    using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(Path.Combine(path, "data", "intrface", "carimage", $"{carName}CI", "tiffrgb", $"{filename}.tif"))))
                    {
                        return new Bitmap((Bitmap)Image.FromStream(ms));
                    }
                }

                if (Directory.Exists(Path.Combine(path, "data", "intrface", "carimage", $"{carName}CI", "pix16")))
                {
                    PIX pix = PIX.Load(Path.Combine(path, "data", "intrface", "carimage", $"{carName}CI", "pix16", $"{filename}.pix"));

                    if (pix is null) { return new Bitmap(64, 64); }

                    pix.Pixies[0].Format = PIXIE.PixelmapFormat.C2_16bitAlpha;
                    return pix.Pixies[0].GetBitmap();
                }

            }
            else if (File.Exists(Path.Combine(path, "data", "intrface", "carimage", $"{carName}CI.twt")))
            {
                TWT twt = TWT.Load(Path.Combine(path, "data", "intrface", "carimage", $"{carName}CI.twt"));

                using (MemoryStream ms = new MemoryStream(twt.Extract(twt.Contents.First(c => string.Compare(c.Name, "PIXIES.P16", true) == 0))))
                {
                    PIX pix = PIX.Load(ms);

                    PIXIE pixie = pix.Pixies.First(p => string.Compare(p.Name, $"{filename}", true) == 0);
                    pixie.Format = PIXIE.PixelmapFormat.C2_16bitAlpha;
                    return pixie.GetBitmap();
                }
            }

            return new Bitmap(64, 64);
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            bool success = false;

            OpponentDetails newCar = mods[lstAvailable.SelectedIndex];

            string newCarName = Path.GetFileNameWithoutExtension(newCar.CarFilename);

            // extract archive (if installing from one)
            if (modZips.ContainsKey(lstAvailable.SelectedIndex))
            {
                using (ZipArchive archive = ZipFile.OpenRead(modZips[lstAvailable.SelectedIndex]))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.Name == "") { continue; }

                        string destinationPath = Path.GetFullPath(Path.Combine(path, entry.FullName));

                        if (destinationPath.StartsWith(path, StringComparison.Ordinal))
                        {
                            if (File.Exists(destinationPath)) { File.Delete(destinationPath); }

                            Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                            entry.ExtractToFile(destinationPath);
                        }
                    }
                }
            }

            // validate installation by checking CarFilename exists
            if (Directory.Exists(Path.Combine(path, "data", "cars", newCarName)))
            {
                success = File.Exists(Path.Combine(path, "data", "cars", newCarName, $"{newCarName}.txt"));
            }
            else
            {
                if (File.Exists(Path.Combine(path, "data", "cars", $"{newCarName}.twt")))
                {
                    TWT twt = TWT.Load(Path.Combine(path, "data", "cars", $"{newCarName}.twt"));

                    success = twt.Contents.Any(entry => string.Compare(entry.Name, $"{newCarName}.txt", true) == 0);
                }
            }

            if (success)
            {
                opponents.Opponents.Add(mods[lstAvailable.SelectedIndex]);
                saveOpponentsTXT();

                reloadUI();
            }
        }

        private void saveOpponentsTXT()
        {
            File.Delete(Path.Combine(path, "data", "opponent.old"));
            File.Move(Path.Combine(path, "data", "opponent.txt"), Path.Combine(path, "data", "opponent.old"));
            opponents.Save(Path.Combine(path, "data", "opponent.txt"));
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            int index = lstInstalled.SelectedIndex;
            OpponentDetails opponent = opponents.Opponents[index];

            using (DocumentWriter dw = new DocumentWriter(Path.Combine(path, $"{Path.GetFileNameWithoutExtension(opponent.CarFilename)}.c2c")))
            {
                opponent.Write(dw);
            }

            opponents.Opponents.RemoveAt(index);

            saveOpponentsTXT();
            reloadUI();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            moveItem(lstInstalled.SelectedIndex, -1);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            moveItem(lstInstalled.SelectedIndex, 1);
        }

        private void moveItem(int index, int offset)
        {
            int newIndex = index + offset;

            OpponentDetails opponent = opponents.Opponents[index];

            lstInstalled.Items.RemoveAt(index);
            lstInstalled.Items.Insert(newIndex, opponent.CarName);

            opponents.Opponents.RemoveAt(index);
            opponents.Opponents.Insert(newIndex, opponent);

            saveOpponentsTXT();

            lstInstalled.SelectedIndex = newIndex;
        }

        private void reloadUI()
        {
            mods.Clear();
            modZips.Clear();
            btnInstall.Enabled = false;
            btnUninstall.Enabled = false;
            lstAvailable.Items.Clear();
            lstInstalled.Items.Clear();
            txtAvailableDescription.Text = "";
            txtInstalledDescription.Text = "";
            pbAvailable.Image = null;
            pbInstalled.Image = null;

            path = Directory.GetCurrentDirectory();
            string twtFile = Path.Combine(path, "data.twt");

            if (File.Exists(twtFile))
            {
                TWT twt = TWT.Load(twtFile);

                foreach (TWTEntry entry in twt.Contents)
                {
                    twt.Extract(entry, Path.Combine(path, "data"));
                }

                File.Move(twtFile, Path.Combine(path, "data.twat"));
            }

            string opponentTXT = Path.Combine(path, "data", "opponent.txt");

            if (File.Exists(opponentTXT))
            {
                opponents = OpponentTXT.Load(opponentTXT);

                foreach (OpponentDetails opponent in opponents.Opponents)
                {
                    lstInstalled.Items.Add(opponent.CarName);
                }
            }

            string carModDir = Path.Combine(path, ".mods", "cars");

            if (Directory.Exists(carModDir))
            {
                foreach (string file in Directory.GetFiles(carModDir, "*.zip"))
                {
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    using (ZipArchive archive = new ZipArchive(fs, ZipArchiveMode.Read))
                    {
                        if (archive.Entries.Any(f => f.Name.EndsWith(".c2c", StringComparison.InvariantCultureIgnoreCase)) &&
                            archive.Entries.Any(f => f.FullName.ToLower().StartsWith(@"data/cars/")))
                        {
                            ZipArchiveEntry entry = archive.Entries.First(f => f.Name.EndsWith(".c2c", StringComparison.InvariantCultureIgnoreCase));

                            using (MemoryStream ms = new MemoryStream())
                            using (BinaryReader br = new BinaryReader(ms))
                            {
                                entry.Open().CopyTo(ms);

                                ms.Seek(0, SeekOrigin.Begin);

                                OpponentDetails details = OpponentDetails.Load(new DocumentParser(br));

                                if (!opponents.Opponents.Any(o => string.Compare(o.CarFilename, details.CarFilename, true) == 0))
                                {
                                    int index = lstAvailable.Items.Add(details.CarName);

                                    modZips.Add(index, file);
                                    mods.Add(details);
                                }
                            }
                        }
                    }
                }
            }

            foreach (string file in Directory.GetFiles(path, "*.c2c"))
            {
                OpponentDetails details = OpponentDetails.Load(new DocumentParser(file));

                if (!mods.Any(m => string.Compare(m.CarFilename, details.CarFilename, true) == 0) &&
                    !opponents.Opponents.Any(o => string.Compare(o.CarFilename, details.CarFilename, true) == 0))
                {
                    lstAvailable.Items.Add(details.CarName);
                    mods.Add(details);
                }
            }
        }
    }
}