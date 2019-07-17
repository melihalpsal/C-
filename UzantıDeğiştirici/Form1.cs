using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportayImageFormatFixer
{
    public partial class Form1 : Form
    {
        public object CheckBox2 { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        static bool cancel = false, no = false, yes = false;
        static int sayac2 = 0, sayac3 = 0, surec = 10000;

        void fonksiyonumuz(string a, string b)
        {
            string[] dir = Directory.GetDirectories(a); int dng1,sayi,yuz,aa2; string yenikayit;
            var yeni = Directory.GetFiles(a); yuz = 10000; aa2 = yeni.Length; aa2 = aa2 / 10;
            bool giriskontrol1 = true, giriskontrol2 = true, giriskontrol3 = true, giriskontrol4 = true;
            if (dir.Length > 1)
            {
                sayi = (dir.Length / 2) + 1; yuz = yuz * sayi;
                surec = surec + yuz - 10000; this.progressBar1.Maximum = surec;
            }
            SaveFileDialog manuel = new SaveFileDialog(); sayac3 = 0;
            string g; DialogResult secenek; DialogResult yesotomatik;
            DialogResult nootomatik; DialogResult cancelotomatik; char cevirici;
            FolderBrowserDialog brwsr = new FolderBrowserDialog(); sayac2 = 0;

            if (checkBox4.Checked == false)  //Üzerine kaydetme seçeneği aktif değilse burası
            {
                foreach (var item2 in yeni)  //Path'de bulunan dosyaları tek tek ele alan döngü
                {
                    var fileInfo = new FileInfo(item2); sayac3++;
                    string uzantiTutucu, stringsayac, stringsayac2; 
                    var hedef = Directory.GetFiles(b); uzantiTutucu = textBox2.Text;
                    string uzantiTutucu2 = textBox4.Text;

                    if (aa2 < 1)
                        aa2 = 1;

                    int z34 = 440 / aa2;

                    if (z34 < 1)
                        z34 = 1;

                    stringsayac = sayac3.ToString(); this.progressBar1.Increment(z34);
                    string[] stringArray = new string[] { uzantiTutucu };
                    string[] stringArray2 = new string[] { textBox4.Text };
                    char[] ihtiyac = new char[100]; char[] ihtiyac2 = new char[100];

                    if (uzantiTutucu != "")
                    {
                        for (dng1 = 0; dng1 < textBox2.Text.Length; dng1++)
                        {
                            if (textBox2.Text[dng1] == '.')
                            {
                                ihtiyac[dng1] = '.';
                                continue;
                            }
                            if (textBox2.Text[dng1] <= 'Z')
                            {
                                cevirici = textBox2.Text[dng1];
                                ihtiyac[dng1] = Convert.ToChar(32 + cevirici);
                            }
                            else
                            {
                                ihtiyac[dng1] = textBox2.Text[dng1];
                            }
                        }

                        textBox2.Text = new String(ihtiyac);
                        uzantiTutucu = textBox2.Text;

                        if (uzantiTutucu[0] != '.')
                        {
                            uzantiTutucu = "." + textBox2.Text;
                        }
                    }
                    else
                    {
                        uzantiTutucu = "";
                    }

                    if (textBox4.Text != "")
                    {
                        for (dng1 = 0; dng1 < textBox4.Text.Length; dng1++)
                        {
                            if (textBox4.Text[dng1] == '.')
                            {
                                ihtiyac2[dng1] = '.';
                                continue;
                            }
                            if (textBox4.Text[dng1] <= 'Z')
                            {
                                cevirici = textBox4.Text[dng1];
                                ihtiyac2[dng1] = Convert.ToChar(32 + cevirici);
                            }
                            else
                            {
                                ihtiyac2[dng1] = textBox4.Text[dng1];
                            }
                        }

                        textBox4.Text = new String(ihtiyac2);
                        uzantiTutucu2 = textBox4.Text;

                        if (uzantiTutucu2[0] != '.')
                        {
                            uzantiTutucu2 = '.' + textBox4.Text;
                        }
                        textBox4.Text = uzantiTutucu2;
                    }
                    else
                    {
                        textBox4.Text = "";
                    }

                    if (radioButton4.Checked == true)  //Belirli uzantıdaki dosyalara uygulanacaksa burası
                    {
                        if (textBox4.Text != fileInfo.Extension)  //Belirlenen uzantı ile dosyanın uzantısı eşit değilse burası
                        {
                            sayac3--; continue;  //Dosyanın uzantısı istenilen uzantı olmadığından bu dosyayı atla
                        }
                    }

                    if (radioButton1.Checked == true) //Belirlediğimiz uzantı,dosya uzantısının yanına eklenecekse burası
                    {
                        if (checkBox1.Checked == true)  //Dosyalara toplu isim girmek istiyorsak burası
                        {
                            if (hedef.Length == 0) //Dosyayı oluşturacağımız klasörde başka dosya yoksa burası (İsim çakışması olmasın)
                            {
                                yenikayit = b + "\\" + stringsayac + "-)" + textBox3.Text + fileInfo.Extension + uzantiTutucu;
                                File.Copy(@fileInfo.FullName, @yenikayit);
                            }
                            else
                            {
                                foreach (var item3 in hedef)
                                {
                                    var fileInfo2 = new FileInfo(item3);
                                    if (fileInfo2.Name == (stringsayac + "-)" + textBox3.Text + fileInfo.Extension + uzantiTutucu))  //Klasördeki başka dosya ismiyle eşleşme varsa burası
                                    {
                                        giriskontrol4 = false;
                                        if (yes == true)
                                        {
                                            yenikayit = b + "\\" + stringsayac + "-)" + textBox3.Text + fileInfo.Extension + uzantiTutucu;
                                            File.Delete(yenikayit);  File.Copy(@fileInfo.FullName, @yenikayit);
                                        }
                                        else if (no == true)
                                        {
                                            sayac2++; stringsayac2 = "UzantıDeğiştirici(" + sayac2.ToString() + ")-";
                                            yenikayit = b + "\\" + stringsayac2 + textBox3.Text + fileInfo.Extension + uzantiTutucu;
                                            File.Copy(@fileInfo.FullName, @yenikayit);
                                        }
                                        else if (cancel == true)
                                        {
                                        }
                                        else
                                        {
                                            secenek = MessageBox.Show("Aynı isimde başka bir dosya var. Üzerine yazılsın mı?", "Uyarı", MessageBoxButtons.YesNoCancel,
                                                      MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                            if (secenek == DialogResult.Yes)
                                            {
                                                yenikayit = b + "\\" + stringsayac + "-)" + textBox3.Text + fileInfo.Extension + uzantiTutucu;
                                                File.Delete(yenikayit); File.Copy(@fileInfo.FullName, @yenikayit);
                                                yesotomatik = MessageBox.Show("Her çakışma için bu seçenek tekrarlansın mı ?", "Otomatik", MessageBoxButtons.YesNo,
                                                              MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                if (yesotomatik == DialogResult.Yes)
                                                {
                                                    yes = true;
                                                }
                                            }
                                            else if (secenek == DialogResult.No)
                                            {
                                                nootomatik = MessageBox.Show("Otomatik isim verilsin mi ?", "Otomatik", MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                if (nootomatik == DialogResult.Yes)
                                                {
                                                    sayac2++; stringsayac2 = "UzantıDeğiştirici(" + sayac2.ToString() + ")-";
                                                    yenikayit = b + "\\" + stringsayac2 + textBox3.Text + fileInfo.Extension + uzantiTutucu;
                                                    File.Copy(@fileInfo.FullName, @yenikayit); no = true;
                                                }
                                                else
                                                {
                                                    manuel.InitialDirectory = b + "\\";
                                                    manuel.FileName = stringsayac + "-)" + textBox3.Text + fileInfo.Extension + uzantiTutucu;
                                                    if (manuel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                                    {
                                                        yenikayit = manuel.FileName;
                                                        File.Copy(@fileInfo.FullName, @yenikayit);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                cancelotomatik = MessageBox.Show("Her çakışma için bu seçenek tekrarlansın mı ?", "Otomatik", MessageBoxButtons.YesNo,
                                                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                if (cancelotomatik == DialogResult.Yes)
                                                {
                                                    cancel = true;
                                                }
                                            }
                                        }
                                        break;
                                    }
                                }
                                if (giriskontrol4)  //Klasördeki başka dosya ismiyle eşleşme yoksa burası
                                {
                                    yenikayit = b + "\\" + stringsayac + "-)" + textBox3.Text + fileInfo.Extension + uzantiTutucu;
                                    File.Copy(@fileInfo.FullName, @yenikayit);
                                }

                                giriskontrol4 = true;
                            }
                        }

                        else  //Dosyalara toplu isim girmek istemiyorsan burası
                        {
                            if (hedef.Length == 0)  //Dosyayı oluşturacağımız klasörde başka dosya yoksa burası (İsim çakışması olmasın)
                            {
                                string yenikayit2 = b + "\\" + fileInfo.Name + uzantiTutucu;
                                File.Copy(@fileInfo.FullName, @yenikayit2);
                            }
                            else  //Dosyayı oluşturacağımız klasörde başka dosya yoksa varsa burası
                            {
                                foreach (var item3 in hedef)
                                {
                                    var fileInfo2 = new FileInfo(item3);
                                    if (fileInfo2.Name == (fileInfo.Name + uzantiTutucu)) //Klasördeki başka dosya ismiyle eşleşme varsa burası
                                    {
                                        giriskontrol3 = false;
                                        if (yes == true)
                                        {
                                            yenikayit = b + "\\" + fileInfo.Name + uzantiTutucu;
                                            File.Delete(yenikayit); File.Copy(@fileInfo.FullName, @yenikayit);
                                        }
                                        else if (no == true)
                                        {
                                            sayac2++; stringsayac2 = "UzantıDeğiştirici(" + sayac2.ToString() + ")-";
                                            yenikayit = b + "\\" + stringsayac2 + fileInfo.Name + uzantiTutucu;
                                            File.Copy(@fileInfo.FullName, @yenikayit);
                                        }
                                        else if (cancel == true)
                                        {
                                        }
                                        else
                                        {
                                            secenek = MessageBox.Show("Aynı isimde başka bir dosya var. Üzerine yazılsın mı?", "Uyarı", MessageBoxButtons.YesNoCancel,
                                                      MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                            if (secenek == DialogResult.Yes)
                                            {
                                                yenikayit = b + "\\" + fileInfo.Name + uzantiTutucu;
                                                File.Delete(yenikayit); File.Copy(@fileInfo.FullName, @yenikayit);
                                                yesotomatik = MessageBox.Show("Her çakışma için bu seçenek tekrarlansın mı ?", "Otomatik", MessageBoxButtons.YesNo,
                                                              MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                if (yesotomatik == DialogResult.Yes)
                                                {
                                                    yes = true;
                                                }
                                            }
                                            else if (secenek == DialogResult.No)
                                            {
                                                nootomatik = MessageBox.Show("Otomatik isim verilsin mi ?", "Otomatik", MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                if (nootomatik == DialogResult.Yes)
                                                {
                                                    sayac2++; stringsayac2 = "UzantıDeğiştirici(" + sayac2.ToString() + ")-";
                                                    yenikayit = b + "\\" + stringsayac2 + fileInfo.Name + uzantiTutucu;
                                                    File.Copy(@fileInfo.FullName, @yenikayit); no = true;
                                                }
                                                else
                                                {
                                                    manuel.InitialDirectory = b + "\\";
                                                    manuel.FileName = fileInfo.Name + uzantiTutucu;

                                                    if (manuel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                                    {
                                                        yenikayit = manuel.FileName;
                                                        File.Copy(@fileInfo.FullName, @yenikayit);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                cancelotomatik = MessageBox.Show("Her çakışma için bu seçenek tekrarlansın mı ?", "Otomatik", MessageBoxButtons.YesNo,
                                                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                if (cancelotomatik == DialogResult.Yes)
                                                {
                                                    cancel = true;
                                                }
                                            }
                                        }
                                        break;
                                    }
                                }
                                if (giriskontrol3) //Klasördeki başka dosya ismiyle eşleşme yoksa burası
                                {
                                    yenikayit = b + "\\" + fileInfo.Name + uzantiTutucu;
                                    File.Copy(@fileInfo.FullName, @yenikayit);
                                }

                                giriskontrol3 = true;
                            }
                        }

                    }

                    else if (radioButton2.Checked == true) //Belirlediğimiz uzantı,dosyanın uzantısının yerine yazılcaksa burası ?
                    {
                        if (checkBox1.Checked == true) //Dosyalara toplu isim girmek istiyorsak burası ?
                        {
                            if (hedef.Length == 0) //Dosyayı oluşturacağımız klasörde başka dosya yoksa burası ? (İsim çakışması olmasın)
                            {
                                yenikayit = b + "\\" + stringsayac + "-)" + textBox3.Text + uzantiTutucu;
                                File.Copy(@fileInfo.FullName, @yenikayit);
                            }
                            else
                            {
                                foreach (var item3 in hedef)
                                {
                                    var fileInfo2 = new FileInfo(item3);
                                    if (fileInfo2.Name == (stringsayac + "-)" + textBox3.Text + uzantiTutucu)) //Klasördeki başka dosya ismiyle eşleşme varsa burası
                                    {
                                        giriskontrol2 = false;
                                        if (yes == true)
                                        {
                                            yenikayit = b + "\\" + stringsayac + "-)" + textBox3.Text + uzantiTutucu;
                                            File.Delete(yenikayit); File.Copy(@fileInfo.FullName, @yenikayit);
                                        }
                                        else if (no == true)
                                        {
                                            sayac2++; stringsayac2 = "UzantıDeğiştirici(" + sayac2.ToString() + ")-";
                                            yenikayit = b + "\\" + stringsayac2 + textBox3.Text + uzantiTutucu;
                                            File.Copy(@fileInfo.FullName, @yenikayit);
                                        }
                                        else if (cancel == true)
                                        {
                                        }
                                        else
                                        {
                                            secenek = MessageBox.Show("Aynı isimde başka bir dosya var. Üzerine yazılsın mı?", "Uyarı", MessageBoxButtons.YesNoCancel,
                                                      MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                            if (secenek == DialogResult.Yes)
                                            {
                                                yenikayit = b + "\\" + stringsayac + "-)" + textBox3.Text + uzantiTutucu;
                                                File.Delete(yenikayit); File.Copy(@fileInfo.FullName, @yenikayit);
                                                yesotomatik = MessageBox.Show("Her çakışma için bu seçenek tekrarlansın mı ?", "Otomatik", MessageBoxButtons.YesNo,
                                                              MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                if (yesotomatik == DialogResult.Yes)
                                                {
                                                    yes = true;
                                                }
                                            }
                                            else if (secenek == DialogResult.No)
                                            {
                                                nootomatik = MessageBox.Show("Otomatik isim verilsin mi ?", "Otomatik", MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                if (nootomatik == DialogResult.Yes)
                                                {
                                                    sayac2++; stringsayac2 = "UzantıDeğiştirici(" + sayac2.ToString() + ")-";
                                                    yenikayit = b + "\\" + stringsayac2 + textBox3.Text + uzantiTutucu;
                                                    File.Copy(@fileInfo.FullName, @yenikayit); no = true;
                                                }
                                                else
                                                {
                                                    manuel.InitialDirectory = b + "\\";
                                                    manuel.FileName = stringsayac + "-)" + textBox3.Text + uzantiTutucu;
                                                    if (manuel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                                    {
                                                        yenikayit = manuel.FileName;
                                                        File.Copy(@fileInfo.FullName, @yenikayit);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                cancelotomatik = MessageBox.Show("Her çakışma için bu seçenek tekrarlansın mı ?", "Otomatik", MessageBoxButtons.YesNo,
                                                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                if (cancelotomatik == DialogResult.Yes)
                                                {
                                                    cancel = true;
                                                }
                                            }
                                        }
                                        break;
                                    }
                                }
                                if (giriskontrol2)  //Klasördeki başka dosya ismiyle eşleşme yoksa burası
                                {
                                    yenikayit = b + "\\" + stringsayac + "-)" + textBox3.Text + uzantiTutucu;
                                    File.Copy(@fileInfo.FullName, @yenikayit);
                                }

                                giriskontrol2 = true;
                            }
                        }

                        else  //Dosyalara toplu isim girmek istemiyorsan burası
                        {
                            string uzantıTutucu2, isimTutucu; int isimUzunlugu, uzantıUzunlugu;
                            uzantıTutucu2 = fileInfo.Extension;
                            isimTutucu = fileInfo.Name;
                            uzantıUzunlugu = uzantıTutucu2.Length;
                            isimUzunlugu = isimTutucu.Length;
                            char[] yeniDosyaIsmi = new char[isimUzunlugu - uzantıUzunlugu];
                            g = "";

                            for (int i = 0; i < (isimUzunlugu - uzantıUzunlugu); i++)
                            {
                                yeniDosyaIsmi[i] = isimTutucu[i];
                                g = g + yeniDosyaIsmi[i].ToString();
                            }

                            if (hedef.Length == 0) //Dosyayı oluşturacağımız klasörde başka dosya yoksa burası (İsim çakışması olmasın)
                            {
                                yenikayit = b + "\\" + g + uzantiTutucu;
                                File.Copy(@fileInfo.FullName, @yenikayit);
                            }
                            else //Dosyayı oluşturacağımız klasörde başka dosyalar varsa burası
                            {
                                foreach (var item3 in hedef)
                                {
                                    var fileInfo2 = new FileInfo(item3);
                                    if (fileInfo2.Name == (g + uzantiTutucu)) //Başka bir dosya ismiyle eşleşme varsa burası
                                    {
                                        giriskontrol1 = false;
                                        if (yes == true)
                                        {
                                            yenikayit = b + "\\" + g + uzantiTutucu;
                                            File.Delete(yenikayit); File.Copy(@fileInfo.FullName, @yenikayit);
                                        }
                                        else if (no == true)
                                        {
                                            sayac2++; stringsayac2 = "UzantıDeğiştirici(" + sayac2.ToString() + ")-";
                                            yenikayit = b + "\\" + stringsayac2 + g + uzantiTutucu;
                                            File.Copy(@fileInfo.FullName, @yenikayit);
                                        }
                                        else if (cancel == true)
                                        {
                                        }
                                        else
                                        {
                                            secenek = MessageBox.Show("Aynı isimde başka bir dosya var. Üzerine yazılsın mı?", "Uyarı", MessageBoxButtons.YesNoCancel,
                                                      MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                            if (secenek == DialogResult.Yes)
                                            {
                                                yenikayit = b + "\\" + g + uzantiTutucu;
                                                File.Delete(yenikayit); File.Copy(@fileInfo.FullName, @yenikayit);
                                                yesotomatik = MessageBox.Show("Her çakışma için bu seçenek tekrarlansın mı ?", "Otomatik", MessageBoxButtons.YesNo,
                                                              MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                if (yesotomatik == DialogResult.Yes)
                                                {
                                                    yes = true;
                                                }
                                            }
                                            else if (secenek == DialogResult.No)
                                            {
                                                nootomatik = MessageBox.Show("Otomatik isim verilsin mi ?", "Otomatik", MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                if (nootomatik == DialogResult.Yes)
                                                {
                                                    sayac2++; stringsayac2 = "UzantıDeğiştirici(" + sayac2.ToString() + ")-";
                                                    yenikayit = b + "\\" + stringsayac2 + g + uzantiTutucu;
                                                    File.Copy(@fileInfo.FullName, @yenikayit); no = true;
                                                }
                                                else
                                                {
                                                    manuel.InitialDirectory = b + "\\";
                                                    manuel.FileName = g + uzantiTutucu;
                                                    if (manuel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                                    {
                                                        yenikayit = manuel.FileName;
                                                        File.Copy(@fileInfo.FullName, @yenikayit);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                cancelotomatik = MessageBox.Show("Her çakışma için bu seçenek tekrarlansın mı ?", "Otomatik", MessageBoxButtons.YesNo,
                                                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                if (cancelotomatik == DialogResult.Yes)
                                                {
                                                    cancel = true;
                                                }
                                            }
                                        }
                                        break;
                                    }
                                }
                                if (giriskontrol1) //Başka bir dosya ismiyle eşleşme yoksa burası
                                {
                                    yenikayit = b + "\\" + g + uzantiTutucu;
                                    File.Copy(@fileInfo.FullName, @yenikayit);
                                }

                                giriskontrol1 = true;
                            }
                        }
                    }
                    textBox1.Text += fileInfo.FullName + Environment.NewLine; //Geniş textbox'a çıktı alma
                }
            }

            if (checkBox4.Checked == true)  //Üzerine kaydetme seçeneği aktifse burası
            {
                var hedef = yeni; int bocek = -1;

                foreach (var item2 in yeni)  //Path'de bulunan dosyaları tek tek ele alan döngü
                {
                    var fileInfo = new FileInfo(item2); sayac3++;
                    string uzantiTutucu, stringsayac, stringsayac2;
                    uzantiTutucu = textBox2.Text; bocek++;
                    string uzantiTutucu2 = textBox4.Text;

                    if (aa2 < 1)
                        aa2 = 1;

                    int z34 = 440 / aa2;

                    if (z34 < 1)
                        z34 = 1;

                    stringsayac = sayac3.ToString(); this.progressBar1.Increment(z34);
                    string[] stringArray = new string[] { uzantiTutucu };
                    string[] stringArray2 = new string[] { textBox4.Text };
                    char[] ihtiyac = new char[100]; char[] ihtiyac2 = new char[100];

                    if (uzantiTutucu != "")
                    {
                        for (dng1 = 0; dng1 < textBox2.Text.Length; dng1++)
                        {
                            if (textBox2.Text[dng1] == '.')
                            {
                                ihtiyac[dng1] = '.';
                                continue;
                            }
                            if (textBox2.Text[dng1] <= 'Z')
                            {
                                cevirici = textBox2.Text[dng1];
                                ihtiyac[dng1] = Convert.ToChar(32 + cevirici);
                            }
                            else
                            {
                                ihtiyac[dng1] = textBox2.Text[dng1];
                            }
                        }

                        textBox2.Text = new String(ihtiyac);
                        uzantiTutucu = textBox2.Text;

                        if (uzantiTutucu[0] != '.')
                        {
                            uzantiTutucu = "." + textBox2.Text;
                        }
                    }
                    else
                    {
                        uzantiTutucu = "";
                    }

                    if (textBox4.Text != "")
                    {
                        for (dng1 = 0; dng1 < textBox4.Text.Length; dng1++)
                        {
                            if (textBox4.Text[dng1] == '.')
                            {
                                ihtiyac2[dng1] = '.';
                                continue;
                            }
                            if (textBox4.Text[dng1] <= 'Z')
                            {
                                cevirici = textBox4.Text[dng1];
                                ihtiyac2[dng1] = Convert.ToChar(32 + cevirici);
                            }
                            else
                            {
                                ihtiyac2[dng1] = textBox4.Text[dng1];
                            }
                        }

                        textBox4.Text = new String(ihtiyac2);
                        uzantiTutucu2 = textBox4.Text;

                        if (uzantiTutucu2[0] != '.')
                        {
                            uzantiTutucu2 = '.' + textBox4.Text;
                        }
                        textBox4.Text = uzantiTutucu2;
                    }
                    else
                    {
                        textBox4.Text = "";
                    }
                    if (radioButton4.Checked == true)  //Belirli uzantıdaki dosyalara uygulanacaksa burası
                    {
                        if (textBox4.Text != fileInfo.Extension)  //Belirlenen uzantı ile dosyanın uzantısı eşit değilse burası
                        {
                            sayac3--; continue;  //Dosyanın uzantısı istenilen uzantı olmadığından bu dosyayı atla
                        }
                    }

                    if (radioButton1.Checked == true) //Belirlediğimiz uzantı,dosya uzantısının yanına eklenecekse burası
                    {
                        if (checkBox1.Checked == true)  //Dosyalara toplu isim girmek istiyorsak burası
                        {
                            foreach (var item3 in hedef)
                            {
                                var fileInfo2 = new FileInfo(item3);
                                if (fileInfo2.Name == (stringsayac + "-)" + textBox3.Text + fileInfo.Extension + uzantiTutucu))  //Klasördeki başka dosya ismiyle eşleşme varsa burası
                                {
                                    giriskontrol4 = false;
                                    if (yes == true)
                                    {
                                        yenikayit = a + "\\" + stringsayac + "-)" + textBox3.Text + fileInfo.Extension + uzantiTutucu;
                                        File.Delete(yenikayit); File.Copy(@fileInfo.FullName, @yenikayit); File.Delete(item2); hedef[bocek] = yenikayit;
                                    }
                                    else if (no == true)
                                    {
                                        sayac2++; stringsayac2 = "UzantıDeğiştirici(" + sayac2.ToString() + ")-";
                                        yenikayit = a + "\\" + stringsayac2 + textBox3.Text + fileInfo.Extension + uzantiTutucu;
                                        File.Copy(@fileInfo.FullName, @yenikayit); File.Delete(item2); hedef[bocek] = yenikayit;
                                    }
                                    else if (cancel == true)
                                    {
                                    }
                                    else
                                    {
                                        secenek = MessageBox.Show("Aynı isimde başka bir dosya var. Üzerine yazılsın mı?", "Uyarı", MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                        if (secenek == DialogResult.Yes)
                                        {
                                            yenikayit = a + "\\" + stringsayac + "-)" + textBox3.Text + fileInfo.Extension + uzantiTutucu;
                                            File.Delete(yenikayit); File.Copy(@fileInfo.FullName, @yenikayit); File.Delete(item2); hedef[bocek] = yenikayit;
                                            yesotomatik = MessageBox.Show("Her çakışma için bu seçenek tekrarlansın mı ?", "Otomatik", MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                            if (yesotomatik == DialogResult.Yes)
                                            {
                                                yes = true;
                                            }
                                        }
                                        else if (secenek == DialogResult.No)
                                        {
                                            nootomatik = MessageBox.Show("Otomatik isim verilsin mi ?", "Otomatik", MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                            if (nootomatik == DialogResult.Yes)
                                            {
                                                sayac2++; stringsayac2 = "UzantıDeğiştirici(" + sayac2.ToString() + ")-";
                                                yenikayit = a + "\\" + stringsayac2 + textBox3.Text + fileInfo.Extension + uzantiTutucu;
                                                File.Copy(@fileInfo.FullName, @yenikayit); File.Delete(item2); hedef[bocek] = yenikayit;
                                                no = true;
                                            }
                                            else
                                            {
                                                manuel.InitialDirectory = a + "\\";
                                                manuel.FileName = stringsayac + "-)" + textBox3.Text + fileInfo.Extension + uzantiTutucu;
                                                if (manuel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                                {
                                                    yenikayit = manuel.FileName;
                                                    File.Copy(@fileInfo.FullName, @yenikayit); File.Delete(item2); hedef[bocek] = yenikayit;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            cancelotomatik = MessageBox.Show("Her çakışma için bu seçenek tekrarlansın mı ?", "Otomatik", MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                            if (cancelotomatik == DialogResult.Yes)
                                            {
                                                cancel = true;
                                            }
                                        }
                                    }
                                    break;
                                }
                            }
                            if (giriskontrol4)  //Klasördeki başka dosya ismiyle eşleşme yoksa burası
                            {
                                yenikayit = a + "\\" + stringsayac + "-)" + textBox3.Text + fileInfo.Extension + uzantiTutucu;
                                File.Copy(@fileInfo.FullName, @yenikayit); File.Delete(item2); hedef[bocek] = yenikayit;
                            }

                            giriskontrol4 = true;
                        }

                        else  //Dosyalara toplu isim girmek istemiyorsan burası
                        {
                            foreach (var item3 in hedef)
                            {
                                var fileInfo2 = new FileInfo(item3);
                                if (fileInfo2.Name == (fileInfo.Name + uzantiTutucu)) //Klasördeki başka dosya ismiyle eşleşme varsa burası
                                {
                                    giriskontrol3 = false;
                                    if (yes == true)
                                    {
                                        yenikayit = a + "\\" + fileInfo.Name + uzantiTutucu;
                                        File.Delete(yenikayit); File.Copy(@fileInfo.FullName, @yenikayit); File.Delete(item2); hedef[bocek] = yenikayit;
                                    }
                                    else if (no == true)
                                    {
                                        sayac2++; stringsayac2 = "UzantıDeğiştirici(" + sayac2.ToString() + ")-";
                                        yenikayit = a + "\\" + stringsayac2 + fileInfo.Name + uzantiTutucu;
                                        File.Copy(@fileInfo.FullName, @yenikayit); File.Delete(item2); hedef[bocek] = yenikayit;
                                    }
                                    else if (cancel == true)
                                    {
                                    }
                                    else
                                    {
                                        secenek = MessageBox.Show("Aynı isimde başka bir dosya var. Üzerine yazılsın mı?", "Uyarı", MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                        if (secenek == DialogResult.Yes)
                                        {
                                            yenikayit = a + "\\" + fileInfo.Name + uzantiTutucu;
                                            File.Delete(yenikayit); File.Copy(@fileInfo.FullName, @yenikayit); File.Delete(item2); hedef[bocek] = yenikayit;
                                            yesotomatik = MessageBox.Show("Her çakışma için bu seçenek tekrarlansın mı ?", "Otomatik", MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                            if (yesotomatik == DialogResult.Yes)
                                            {
                                                yes = true;
                                            }
                                        }
                                        else if (secenek == DialogResult.No)
                                        {
                                            nootomatik = MessageBox.Show("Otomatik isim verilsin mi ?", "Otomatik", MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                            if (nootomatik == DialogResult.Yes)
                                            {
                                                sayac2++; stringsayac2 = "UzantıDeğiştirici(" + sayac2.ToString() + ")-";
                                                yenikayit = a + "\\" + stringsayac2 + fileInfo.Name + uzantiTutucu;
                                                File.Copy(@fileInfo.FullName, @yenikayit); File.Delete(item2); hedef[bocek] = yenikayit;
                                                no = true;
                                            }
                                            else
                                            {
                                                manuel.InitialDirectory = a + "\\";
                                                manuel.FileName = fileInfo.Name + uzantiTutucu;

                                                if (manuel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                                {
                                                    yenikayit = manuel.FileName;
                                                    File.Copy(@fileInfo.FullName, @yenikayit); File.Delete(item2); hedef[bocek] = yenikayit;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            cancelotomatik = MessageBox.Show("Her çakışma için bu seçenek tekrarlansın mı ?", "Otomatik", MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                            if (cancelotomatik == DialogResult.Yes)
                                            {
                                                cancel = true;
                                            }
                                        }
                                    }
                                    break;
                                }
                            }
                            if (giriskontrol3) //Klasördeki başka dosya ismiyle eşleşme yoksa burası
                            {
                                yenikayit = a + "\\" + fileInfo.Name + uzantiTutucu;
                                File.Copy(@fileInfo.FullName, @yenikayit); File.Delete(item2); hedef[bocek] = yenikayit;
                            }

                            giriskontrol3 = true;
                        }

                    }

                    else if (radioButton2.Checked == true) //Belirlediğimiz uzantı,dosyanın uzantısının yerine yazılcaksa burası ?
                    {
                        if (checkBox1.Checked == true) //Dosyalara toplu isim girmek istiyorsak burası ?
                        {
                            foreach (var item3 in hedef)
                            {
                                var fileInfo2 = new FileInfo(item3);
                                if (fileInfo2.Name == (stringsayac + "-)" + textBox3.Text + uzantiTutucu)) //Klasördeki başka dosya ismiyle eşleşme varsa burası
                                {
                                    giriskontrol2 = false;
                                    if (yes == true)
                                    {
                                        yenikayit = a + "\\" + stringsayac + "-)" + textBox3.Text + uzantiTutucu;
                                        File.Delete(yenikayit); File.Copy(@fileInfo.FullName, @yenikayit); File.Delete(item2); hedef[bocek] = yenikayit;
                                    }
                                    else if (no == true)
                                    {
                                        sayac2++; stringsayac2 = "UzantıDeğiştirici(" + sayac2.ToString() + ")-";
                                        yenikayit = a + "\\" + stringsayac2 + textBox3.Text + uzantiTutucu;
                                        File.Copy(@fileInfo.FullName, @yenikayit); File.Delete(item2); hedef[bocek] = yenikayit;
                                    }
                                    else if (cancel == true)
                                    {
                                    }
                                    else
                                    {
                                        secenek = MessageBox.Show("Aynı isimde başka bir dosya var. Üzerine yazılsın mı?", "Uyarı", MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                        if (secenek == DialogResult.Yes)
                                        {
                                            yenikayit = a + "\\" + stringsayac + "-)" + textBox3.Text + uzantiTutucu;
                                            File.Delete(yenikayit); File.Copy(@fileInfo.FullName, @yenikayit); File.Delete(item2); hedef[bocek] = yenikayit;
                                            yesotomatik = MessageBox.Show("Her çakışma için bu seçenek tekrarlansın mı ?", "Otomatik", MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                            if (yesotomatik == DialogResult.Yes)
                                            {
                                                yes = true;
                                            }
                                        }
                                        else if (secenek == DialogResult.No)
                                        {
                                            nootomatik = MessageBox.Show("Otomatik isim verilsin mi ?", "Otomatik", MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                            if (nootomatik == DialogResult.Yes)
                                            {
                                                sayac2++; stringsayac2 = "UzantıDeğiştirici(" + sayac2.ToString() + ")-";
                                                yenikayit = a + "\\" + stringsayac2 + textBox3.Text + uzantiTutucu;
                                                File.Copy(@fileInfo.FullName, @yenikayit); File.Delete(item2); hedef[bocek] = yenikayit;
                                                no = true;
                                            }
                                            else
                                            {
                                                manuel.InitialDirectory = a + "\\";
                                                manuel.FileName = stringsayac + "-)" + textBox3.Text + uzantiTutucu;
                                                if (manuel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                                {
                                                    yenikayit = manuel.FileName;
                                                    File.Copy(@fileInfo.FullName, @yenikayit); File.Delete(item2); hedef[bocek] = yenikayit;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            cancelotomatik = MessageBox.Show("Her çakışma için bu seçenek tekrarlansın mı ?", "Otomatik", MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                            if (cancelotomatik == DialogResult.Yes)
                                            {
                                                cancel = true;
                                            }
                                        }
                                    }
                                    break;
                                }
                            }
                            if (giriskontrol2)  //Klasördeki başka dosya ismiyle eşleşme yoksa burası
                            {
                                yenikayit = a + "\\" + stringsayac + "-)" + textBox3.Text + uzantiTutucu;
                                File.Copy(@fileInfo.FullName, @yenikayit); File.Delete(item2); hedef[bocek] = yenikayit;
                            }

                            giriskontrol2 = true;
                        }

                        else  //Dosyalara toplu isim girmek istemiyorsan burası
                        {
                            string uzantıTutucu2, isimTutucu; int isimUzunlugu, uzantıUzunlugu;
                            uzantıTutucu2 = fileInfo.Extension;
                            isimTutucu = fileInfo.Name;
                            uzantıUzunlugu = uzantıTutucu2.Length;
                            isimUzunlugu = isimTutucu.Length;
                            char[] yeniDosyaIsmi = new char[isimUzunlugu - uzantıUzunlugu];
                            g = "";

                            for (int i = 0; i < (isimUzunlugu - uzantıUzunlugu); i++)
                            {
                                yeniDosyaIsmi[i] = isimTutucu[i];
                                g = g + yeniDosyaIsmi[i].ToString();
                            }
                            foreach (var item3 in hedef)
                            {
                                var fileInfo2 = new FileInfo(item3);
                                if (fileInfo2.Name == (g + uzantiTutucu)) //Başka bir dosya ismiyle eşleşme varsa burası
                                {
                                    giriskontrol1 = false;
                                    if (yes == true)
                                    {
                                        yenikayit = a + "\\" + g + uzantiTutucu;
                                        File.Delete(yenikayit); File.Copy(@fileInfo.FullName, @yenikayit); File.Delete(item2); hedef[bocek] = yenikayit;
                                    }
                                    else if (no == true)
                                    {
                                        sayac2++; stringsayac2 = "UzantıDeğiştirici(" + sayac2.ToString() + ")-";
                                        yenikayit = a + "\\" + stringsayac2 + g + uzantiTutucu;
                                        File.Copy(@fileInfo.FullName, @yenikayit); File.Delete(item2); hedef[bocek] = yenikayit;
                                    }
                                    else if (cancel == true)
                                    {
                                    }
                                    else
                                    {
                                        secenek = MessageBox.Show("Aynı isimde başka bir dosya var. Üzerine yazılsın mı?", "Uyarı", MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                        if (secenek == DialogResult.Yes)
                                        {
                                            yenikayit = a + "\\" + g + uzantiTutucu;
                                            File.Delete(yenikayit); File.Copy(@fileInfo.FullName, @yenikayit); File.Delete(item2); hedef[bocek] = yenikayit;
                                            yesotomatik = MessageBox.Show("Her çakışma için bu seçenek tekrarlansın mı ?", "Otomatik", MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                            if (yesotomatik == DialogResult.Yes)
                                            {
                                                yes = true;
                                            }
                                        }
                                        else if (secenek == DialogResult.No)
                                        {
                                            nootomatik = MessageBox.Show("Otomatik isim verilsin mi ?", "Otomatik", MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                            if (nootomatik == DialogResult.Yes)
                                            {
                                                sayac2++; stringsayac2 = "UzantıDeğiştirici(" + sayac2.ToString() + ")-";
                                                yenikayit = a + "\\" + stringsayac2 + g + uzantiTutucu;
                                                File.Copy(@fileInfo.FullName, @yenikayit); File.Delete(item2); hedef[bocek] = yenikayit;
                                                no = true;
                                            }
                                            else
                                            {
                                                manuel.InitialDirectory = a + "\\";
                                                manuel.FileName = g + uzantiTutucu;
                                                if (manuel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                                {
                                                    yenikayit = manuel.FileName;
                                                    File.Copy(@fileInfo.FullName, @yenikayit); File.Delete(item2); hedef[bocek] = yenikayit;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            cancelotomatik = MessageBox.Show("Her çakışma için bu seçenek tekrarlansın mı ?", "Otomatik", MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                            if (cancelotomatik == DialogResult.Yes)
                                            {
                                                cancel = true;
                                            }
                                        }
                                    }
                                    break;
                                }
                            }
                            if (giriskontrol1) //Başka bir dosya ismiyle eşleşme yoksa burası
                            {
                                yenikayit = a + "\\" + g + uzantiTutucu;
                                File.Copy(@fileInfo.FullName, @yenikayit); File.Delete(item2); hedef[bocek] = yenikayit;
                            }

                            giriskontrol1 = true;
                        }
                    }
                    textBox1.Text += fileInfo.FullName + Environment.NewLine; //Geniş textbox'a çıktı alma
                }
            }

            if (checkBox3.Checked == true) //Tüm alt klasörlere uygulanacaksa burası
            {
                foreach (var klasorlerimiz in dir)
                {
                    fonksiyonumuz(klasorlerimiz, b);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear(); bool kontrol = true;
            string a = label1.Text, b = label2.Text;

            if (a == "")
            {
                MessageBox.Show("Lütfen Kaynak Klasörü Belirtiniz!", "Uyarı");
                kontrol = false;
            }
            if (b == "" && checkBox4.Checked == false)
            {
                MessageBox.Show("Lütfen Hedef Klasörü Belirtiniz!", "Uyarı");
                kontrol = false;
            }
            if (kontrol)
            {
                if (checkBox2.Checked == true)  //Hedef klasör işlemden önce temizlenecekse burası
                {
                    var hedef2 = Directory.GetFiles(b);

                    foreach (var item2 in hedef2)
                        try
                        {
                            File.Delete(item2);
                        }
                        catch
                        {
                        }

                    hedef2 = Directory.GetFiles(b);
                }

                this.timer1.Start(); fonksiyonumuz(a, b); this.progressBar1.Value = surec;
                MessageBox.Show("Uzantılar Başarıyla Değiştirildi", "Mesaj");
                sayac2 = 0; sayac3 = 0; cancel = false; no = false; yes = false;
                this.progressBar1.Value = 0;
            }
        }

        string KlasorYolu;

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Klasor = new FolderBrowserDialog();
            Klasor.ShowDialog(); KlasorYolu = Klasor.SelectedPath;
            label1.Text = KlasorYolu;

            if (checkBox4.Checked == true)
            {
                label2.Text = "";
            }
            if (!Convert.ToBoolean(string.Compare(label1.Text, label2.Text, false)))
            {
                checkBox2.Checked = false;
                checkBox2.Enabled = false;
            }
            else
            {
                if (checkBox4.Checked == false)
                    checkBox2.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Klasor2 = new FolderBrowserDialog();
            Klasor2.ShowDialog(); string KlasorYolu2;
            KlasorYolu2 = Klasor2.SelectedPath; label2.Text = KlasorYolu2;

            if (!Convert.ToBoolean(string.Compare(label1.Text, label2.Text, false)))
            {
                checkBox2.Checked = false;
                checkBox2.Enabled = false;
            }
            else
            {
                checkBox2.Enabled = true;
            }
        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)  //Dosyalara toplu isim girmek istiyor musun ?
            {
                panel3.Visible = true;
            }
            if (checkBox1.Checked == false)
            {
                panel3.Visible = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                textBox4.Visible = true;
                label5.Visible = true;
            }
            if (radioButton4.Checked == false)
            {
                textBox4.Visible = false;
                label5.Visible = false;
            }
        }

        string tutucu = "";

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == false)
            {
                button3.Enabled = true; label2.Text = tutucu;

                if (Convert.ToBoolean(string.Compare(label1.Text, label2.Text, false)))
                {
                    checkBox2.Enabled = true;
                }
            }
            if (checkBox4.Checked == true)
            {
                button3.Enabled = false; checkBox2.Checked = false;
                checkBox2.Enabled = false; tutucu = label2.Text;
                label2.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        
    }
}
