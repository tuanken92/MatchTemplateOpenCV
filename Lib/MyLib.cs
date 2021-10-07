using Newtonsoft.Json;
using MatchTemplateOpenCV.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace MatchTemplateOpenCV.Lib
{

    public enum eTypeFile
    {
        File_Bartender,
        File_Excel,
        File_SerialNumber,
        File_Image
    }



    public enum eFocus
    {
        Focus_Lost,
        Focus_Got
    }



    public class PagingListviewSimplle
    {
        public UInt32 cur_page = 1;
        public UInt32 num_items_per_page = 20;

    }

    public class PagingListview
    {
        public UInt32 cur_page = 1;
        public UInt32 total_page = 1000;
        public UInt32 total_record = 20000;
        public UInt32 num_items_per_page = 20;

        public UInt32 record_start = 0;
        public UInt32 record_end = 20;
    }

    public class MyPermision
    {
        public bool view = false;
        public bool edit = true;
        public bool del = true;
        public bool create = true;

    }
    public static class ViewPermision
    {
        public static MyPermision home = new MyPermision()
        {
            view = true,
            edit = false,
            del = false,
            create = false
        };

        public static MyPermision inventory_all = new MyPermision()
        {
            view = true,
            edit = false,
            del = false,
            create = false
        };
        public static MyPermision inventory_warning = new MyPermision()
        {
            view = true,
            edit = false,
            del = false,
            create = false
        };
        public static MyPermision inventory_list_sku = new MyPermision()
        {
            view = true,
            edit = false,
            del = false,
            create = false
        };


        public static MyPermision import;
        public static MyPermision export;

        public static MyPermision product;
        public static MyPermision customer;
        public static MyPermision warehouse;
        public static MyPermision user;
        public static MyPermision brand;
        public static MyPermision category;
        public static MyPermision unit;

        public static MyPermision setting;
        public static MyPermision dev;
    }

    public class MyDefine
    {

        public static uint WM_LBUTTONDOWN = 0x201;
        public static uint WM_LBUTTONUP = 0x202;

        public static readonly string workingDirectory = Environment.CurrentDirectory;
        public static readonly string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
        public static readonly string workspaceDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        public static readonly string resources_folder = String.Format($"{workingDirectory}\\resources");

        public static readonly string regex_get_image_file = @"[^\s]+(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$";
        public static readonly string regex_get_ip = @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b";


        public static string xpath_btn_login = "//*[@id=\"wrapper\"]/nav[1]/div[3]/a[1]/b";
        public static string xpath_edt_username = "//*[@id=\"focus\"]";
        public static string xpath_edt_pass = "/html/body/div/div[2]/div/div/form/div[2]/input";

        public static string xpath_btn_signin = "//*[@id=\"loginbtn\"]";

        public static string xpath_cbb_speed = "//*[@id=\"1_type\"]";
        public static string xpath_speed_50 = "//*[@id=\"1_type\"]/ul/li[1]";
        public static string xpath_speed_75 = "//*[@id=\"1_type\"]/ul/li[2]";
        public static string xpath_speed_100 = "//*[@id=\"1_type\"]/ul/li[3]";
        public static string xpath_speed_150 = "//*[@id=\"1_type\"]/ul/li[4]";
        public static string xpath_speed_200 = "//*[@id=\"1_type\"]/ul/li[5]";


        public static string xpath_cbb_rotation = "//*[@id=\"3_type\"]";
        public static string xpath_rotation_0 = "//*[@id=\"3_type\"]/ul/li[1]";
        public static string xpath_rotation_90 = "//*[@id=\"3_type\"]/ul/li[2]";
        public static string xpath_rotation_180 = "//*[@id=\"3_type\"]/ul/li[3]";
        public static string xpath_rotation_270 = "//*[@id=\"3_type\"]/ul/li[4]";




        public static string css_darknet = "#page-inner > div > div > table > tbody > tr:nth-child(2) > td:nth-child(2) > span > input[type=text]";
        public static string xpath_btn_save_quatify = "//*[@id=\"button1\"]";

        public static string xpath_btn_upload_img = "//*[@id=\"upload\"]";
        public static string xpath_btn_browser = "//*[@id=\"fileinfo\"]/div[1]/span/button";
        public static string xpath_btn_upload_xxx = "//*[@id=\"fileinfo\"]/div[2]/span"; // //*[@id="upload"]

        public static string url_custom_ip = "192.168.1.222";

        public static string url_config = "http://192.168.1.222/configure/configsummary.lua?pageid=Configure";
        public static string url_config_print_quality = "http://192.168.1.222/configure/edit.lua?pageid=Configure&nodeid=32769&nodename=Print%20Quality&headnodename=Printing&nodetype=9";
        public static string url_config_images = "http://192.168.1.222/manage/imagedetails.lua?pageid=Manage&nodename=images";
        //public static string url_login = "http://192.168.1.222/main/login.lua?pageid=Home";

        //public static int time_wait_login_load = 3000;
        //public static int time_wait_step = 100;

        #region Path file json
        public static readonly string file_brand = String.Format($"{workingDirectory}\\Configs\\brand.json");
        public static readonly string file_category = String.Format($"{workingDirectory}\\Configs\\category.json");
        public static readonly string file_user = String.Format($"{workingDirectory}\\Configs\\user.json");
        public static readonly string file_customer = String.Format($"{workingDirectory}\\Configs\\customer.json");
        public static readonly string file_warehouse = String.Format($"{workingDirectory}\\Configs\\warehouse.json");
        public static readonly string file_product = String.Format($"{workingDirectory}\\Configs\\product.json");
        public static readonly string file_unit = String.Format($"{workingDirectory}\\Configs\\unit.json");
        public static readonly string file_setting = String.Format($"{workingDirectory}\\Configs\\setting.json");
        public static readonly string file_import_product_manager = String.Format($"{workingDirectory}\\Configs\\product_import_manager.json");
        public static readonly string file_export_product_manager = String.Format($"{workingDirectory}\\Configs\\product_export_manager.json");
        public static readonly string import_product_tmp = String.Format($"{workingDirectory}\\Data\\Import\\") + @"product_import_{0}_{1}_{2}.json";
        public static readonly string export_product_tmp = String.Format($"{workingDirectory}\\Data\\Export\\") + @"product_export_{0}_{1}_{2}.json";


        public static readonly string file_config = String.Format($"{workingDirectory}\\Configs\\config_param.json");
        public static readonly string file_excel = String.Format($"{workingDirectory}\\Data\\ImportData.xlsx");

        public static readonly string file_config_format_data = String.Format($"{workingDirectory}\\Data\\configs\\format_data.json");
        public static readonly string file_config_common_param = String.Format($"{workingDirectory}\\Data\\configs\\common_param.json");
        public static readonly string file_config_filter_window = String.Format($"{workingDirectory}\\Data\\configs\\filter_window.json");
        public static readonly string path_load_img_database = @"C:\Program Files\Cognex\VisionPro\Images";
        public static readonly string path_load_vpp_file = @"C:\Users\Admin\Desktop\Vpp_file";
        public static readonly string path_save_images = String.Format("{0}\\Images", projectDirectory);

        public static readonly string key_thh = @"https://tanhungha.com.vn/";
        public static readonly string hash_key = "";
        #endregion

        #region api
        public static string API_OK = "success";
        public static string API_NG = "error";
        public static string API_Warning = "warning";
        public static string API_LOSS_CONNECTION = "network";
        #endregion

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);


        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);



    }

    public class SaveLoadParameter
    {
        public static void Save_Parameter(object param)
        {
            //save
            if (MyLib.File_Is_Exist(MyDefine.file_config))
            {
                Save_Parameter(param, MyDefine.file_config);
            }
            else
            {
                //create folder
                FileInfo fileInfo = new FileInfo(MyDefine.file_config);
                if (!fileInfo.Exists)
                    Directory.CreateDirectory(fileInfo.Directory.FullName);

                //create file
                using (FileStream f = File.Create(MyDefine.file_config))
                {
                    f.Close();
                    Console.WriteLine($"Create file {MyDefine.file_config}");
                }

                //save param to file
                Save_Parameter(param, MyDefine.file_config);
            }
        }

        public static object Load_Parameter(object param)
        {
            if (MyLib.File_Is_Exist(MyDefine.file_config))
            {
                using (StreamReader file = File.OpenText(MyDefine.file_config))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    param = serializer.Deserialize(file, param.GetType());
                }
            }
            else
            {
                MyLib.ShowDlgError($"Not found {MyDefine.file_config}");
                return null;
            }

            return param;
        }

        public static void Save_Parameter(object param, string file_name)
        {
            //save
            if (MyLib.File_Is_Exist(file_name))
            {
                // serialize JSON directly to a file
                Console.WriteLine("Save parameter to file " + file_name);
                using (StreamWriter file = File.CreateText(file_name))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, param);
                }
            }
            else
            {
                //create folder
                FileInfo fileInfo = new FileInfo(file_name);
                if (!fileInfo.Exists)
                    Directory.CreateDirectory(fileInfo.Directory.FullName);

                //create file
                using (FileStream f = File.Create(file_name))
                {
                    f.Close();
                    Console.WriteLine($"Create file {file_name}");
                }

                // serialize JSON directly to a file
                Console.WriteLine("Save parameter to file " + file_name);
                using (StreamWriter file = File.CreateText(file_name))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, param);
                }
            }
        }

        public static object Load_Parameter(object param, string file_name)
        {
            if (MyLib.File_Is_Exist(file_name))
            {
                using (StreamReader file = File.OpenText(file_name))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    param = serializer.Deserialize(file, param.GetType());
                }
            }
            else
            {
                MyLib.ShowDlgError($"Not found {file_name}");
            }

            return param;
        }
    }

    public enum PrintSpeed
    {
        Speed_50,
        Speed_75,
        Speed_100,
        Speed_150,
        Speed_200
    }

    public enum PrintRotation
    {
        Rotation_0,
        Rotation_90,
        Rotation_180,
        Rotation_270
    }

    public class PrintQuality
    {
        public string link = "http://{0}/configure/edit.lua?pageid=Configure&nodeid=32769&nodename=Print%20Quality&headnodename=Printing&nodetype=9";
        public int darknet = 80;
        public PrintSpeed speed = PrintSpeed.Speed_100;
        public PrintRotation rotation = PrintRotation.Rotation_0;

        public bool set_darknet = true;
        public bool set_speed = true;
        public bool set_rotation = false;

        public PrintQuality()
        {
            link = "http://{0}/configure/edit.lua?pageid=Configure&nodeid=32769&nodename=Print%20Quality&headnodename=Printing&nodetype=9";
            darknet = 80;
            speed = PrintSpeed.Speed_100;
            rotation = PrintRotation.Rotation_0;

            set_darknet = true;
            set_speed = true;
            set_rotation = false;
        }

        public void PrintInfor()
        {
            Console.WriteLine("-------PrintQuality---------");
            Console.WriteLine(String.Format($"link = {link}"));
            Console.WriteLine(String.Format($"speed = {speed}, en = {set_speed}"));
            Console.WriteLine(String.Format($"darknet = {darknet}, en = {set_darknet}"));
            Console.WriteLine(String.Format($"rotation = {rotation}, en = {set_rotation}"));
        }
    }

    public enum Img_Type
    {
        Img_bmp,
        Img_jpg,
        Img_png
    }

    public class PrintUploadImage
    {
        public string link = "http://{0}/manage/imagedetails.lua?pageid=Manage&nodename=images";
        public string folder = "";
        public Img_Type type_img = Img_Type.Img_bmp;

        public PrintUploadImage()
        {
            link = "http://{0}/manage/imagedetails.lua?pageid=Manage&nodename=images";
            folder = "";
            type_img = Img_Type.Img_bmp;
        }

        public void PrintInfor()
        {
            Console.WriteLine("-------PrintUploadImage---------");
            Console.WriteLine(String.Format($"link = {link}"));
            Console.WriteLine(String.Format($"folder = {folder}"));
            Console.WriteLine(String.Format($"type_img = {type_img}"));
        }

    }

    public class PrintLogin
    {
        public string link = "http://{0}/main/login.lua?pageid=Home";
        public string user = "itadmin";
        public string pass = "pass";

        public PrintLogin()
        {
            link = "http://{0}/main/login.lua?pageid=Home";
            user = "itadmin";
            pass = "pass";
        }

        public void PrintInfor()
        {
            Console.WriteLine("-------PrintLogin---------");
            Console.WriteLine(String.Format($"link = {link}"));
            Console.WriteLine(String.Format($"user = {user}"));
            Console.WriteLine(String.Format($"pass = {pass}"));
        }
    }

    public class PrintTimeDelay
    {
        public double load_main_page = 2;
        public double load_login = 2;
        public double delay_step = 0.5;
        public double load_browser_dlg = 2;
        public double upload_img_finish = 5;
        public double delay_upload_img = 0.5;

        public void PrintInfor()
        {
            Console.WriteLine("-------PrintTimeDelay---------");
            Console.WriteLine(String.Format($"load_main_page = {load_main_page}"));
            Console.WriteLine(String.Format($"load_login = {load_login}"));
            Console.WriteLine(String.Format($"delay_step = {delay_step}"));

            Console.WriteLine(String.Format($"load_browser_dlg = {load_browser_dlg}"));
            Console.WriteLine(String.Format($"upload_img_finish = {upload_img_finish}"));
            Console.WriteLine(String.Format($"delay_upload_img = {delay_upload_img}"));
        }

    }

    public class PrintParam
    {
        public PrintQuality print_quality;
        public PrintUploadImage print_upload_image;
        public PrintTimeDelay delay;
        public PrintLogin print_login;


        public PrintParam()
        {
            print_login = new PrintLogin();
            print_quality = new PrintQuality();
            print_upload_image = new PrintUploadImage();
            delay = new PrintTimeDelay();
        }
        public void PrintInfor()
        {
            Console.WriteLine("-------PrintParam---------");
            print_quality.PrintInfor();
            print_upload_image.PrintInfor();
            delay.PrintInfor();
        }
    }
    public static class MyParam
    {
        public static string token = null;
        //public static string ip_printer = @"http://192.168.1.222/index.lua";
        //public static string user_printer = "itadmin";
        //public static string pass_printer = "pass";

        public static PrintParam parameter = new PrintParam();


    }
    public class MyLib
    {
        public static List<string> get_list_image_to_upload()
        {
            List<string> list_img = new List<string>();

            DirectoryInfo d = new DirectoryInfo(MyParam.parameter.print_upload_image.folder); //Assuming Test is your Folder
            string type_img = "";
            switch (MyParam.parameter.print_upload_image.type_img)
            {

                case Img_Type.Img_jpg:
                    type_img = "*.jpg";
                    break;
                case Img_Type.Img_png:
                    type_img = "*.png";
                    break;
                case Img_Type.Img_bmp:
                default:
                    type_img = "*.bmp";
                    break;

            }
            FileInfo[] Files = d.GetFiles(type_img); //Getting Text files
            string str = "";

            foreach (FileInfo file in Files)
            {
                str += file.Name + "\r\n";
                list_img.Add(file.FullName);
            }

            return list_img;
        }


        public static List<string> get_list_file_print_to_upload()
        {
            List<string> list_img = new List<string>();

            DirectoryInfo d = new DirectoryInfo(MyParam.parameter.print_upload_image.folder); //Assuming Test is your Folder
            string type_img = "*.prn";

            FileInfo[] Files = d.GetFiles(type_img); //Getting Text files
            string str = "";

            foreach (FileInfo file in Files)
            {
                str += file.Name + "\r\n";
                list_img.Add(file.FullName);
            }

            return list_img;
        }


        public static string GetLocalIPAddress()
        {
            var localhost = "127.0.0.1";
            bool isNetwork = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            if (isNetwork)
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
                return localhost;
            }
            else
            {
                return localhost;
            }
        }

        public static bool File_Is_Exist(string file_name)
        {
            return File.Exists(file_name);
        }

        public static void ShowDlgWarning(string message)
        {
            using (DialogMessage dialogMessage = new DialogMessage(MyDefine.API_Warning, message))
            {
                dialogMessage.ShowDialog();
            }
        }

        public static void ShowDlgInfor(string message)
        {
            using (DialogMessage dialogMessage = new DialogMessage(MyDefine.API_OK, message))
            {
                dialogMessage.ShowDialog();
            }
        }


        public static void ShowDlgError(string message)
        {
            using (DialogMessage dialogMessage = new DialogMessage(MyDefine.API_NG, message))
            {
                dialogMessage.ShowDialog();
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        public extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        public extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        public static void DragWindow(IntPtr hwnd)
        {
            ReleaseCapture();
            SendMessage(hwnd, 0x112, 0xf012, 0);
        }


        
        public static string OpenFileDialog(eTypeFile type_file, string initDirectory = null)
        {
            string file_name = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.ReadOnlyChecked = true;
            openFileDialog.ShowReadOnly = true;

            if(!String.IsNullOrEmpty(initDirectory))
                openFileDialog.InitialDirectory = initDirectory;

            switch(type_file)
            {
                case eTypeFile.File_Bartender:
                    openFileDialog.Title = "Browse BarTender Files";
                    openFileDialog.DefaultExt = "btw";
                    openFileDialog.Filter = "bartender files (*.btw)|*.btw|All files (*.*)|*.*";
                    break;

                case eTypeFile.File_Excel:
                    openFileDialog.Title = "Browse Excel Files";
                    openFileDialog.DefaultExt = "xlsx";
                    openFileDialog.Filter = "excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    break;
                case eTypeFile.File_SerialNumber:
                    openFileDialog.Title = "Browse File Serial Number";
                    openFileDialog.DefaultExt = "xlsx";
                    openFileDialog.Filter = "excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    break;

                case eTypeFile.File_Image:
                    openFileDialog.Title = "Browse File Image";
                    openFileDialog.DefaultExt = "jpg";
                    openFileDialog.Filter = "image files (*.jpg)|*.jpg|All files (*.*)|*.*";
                    break;
            }
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                file_name = openFileDialog.FileName;
            }

            return file_name;
        }

        public static List<string> Get_List_Printer()
        {
            List<string> list_printer = System.Drawing.Printing.PrinterSettings.InstalledPrinters.Cast<string>().ToList();
            return list_printer;
        }

        

        public static bool ScrambledEquals<T>(IEnumerable<T> list1, IEnumerable<T> list2)
        {
            var cnt = new Dictionary<T, int>();
            foreach (T s in list1)
            {
                if (cnt.ContainsKey(s))
                {
                    cnt[s]++;
                }
                else
                {
                    cnt.Add(s, 1);
                }
            }
            foreach (T s in list2)
            {
                if (cnt.ContainsKey(s))
                {
                    cnt[s]--;
                }
                else
                {
                    return false;
                }
            }
            return cnt.Values.All(c => c == 0);
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public static string Encrypt(string decrypted)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(decrypted);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider tripDES = new TripleDESCryptoServiceProvider();

            tripDES.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(MyDefine.hash_key));
            tripDES.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripDES.CreateEncryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
            return Convert.ToBase64String(result);
        }

        public static string Decrypt(string encrypted)
        {
            byte[] data = Convert.FromBase64String(encrypted);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider tripDES = new TripleDESCryptoServiceProvider();

            tripDES.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(MyDefine.hash_key));
            tripDES.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripDES.CreateDecryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
            return UTF8Encoding.UTF8.GetString(result);
        }


        public static DateTime Timestamp_To_Datetime(UInt64 timestamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(timestamp).ToLocalTime();
            return dtDateTime;
        }

        public static UInt64 Datetime_To_TimeStamp(DateTime datetime)
        {
            return (UInt64)(TimeZoneInfo.ConvertTimeToUtc(datetime) - new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds;
        }

        public static Image Download_Image(string fromUrl)
        {
            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                try
                {
                    using (Stream stream = webClient.OpenRead(fromUrl))
                    {
                        return Image.FromStream(stream);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Download {fromUrl} -> exception: {e.Message}");
                    return null;
                }

            }

            //Image img = null;
            //try
            //{
            //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fromUrl);
            //    request.Timeout = 3000;
            //    request.ReadWriteTimeout = 3000;

            //    var wresp = (HttpWebResponse)request.GetResponse();

            //    using (Stream stream = File.OpenRead(fromUrl))
            //    {
            //        img = Image.FromStream(stream);
            //    }

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine($"Download exception: {e.Message}");

            //}

            //return img;
        }

        static public bool Download_Image(string url, string path2save)
        {
            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                try
                {
                    webClient.DownloadFileAsync(new Uri(url), path2save);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Download exception: {e.Message}");
                    return false;
                }

            }
            return true;
        }

        public static void Upload_Image(string dest_address, string file_name, string fpt_username, string pass_word)
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(fpt_username, pass_word);
                    client.UploadFile(dest_address, WebRequestMethods.Ftp.UploadFile, file_name);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Upload exception: {e.Message}");
            }

        }

        

        static readonly string s1 = @"ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚÝàáâãèéêìíòóôõùúýĂăĐđĨĩŨũƠơƯưẠạẢảẤấẦầẨẩẪẫẬậẮắẰằẲẳẴẵẶặẸẹẺẻẼẽẾếỀềỂểỄễỆệỈỉỊịỌọỎỏỐốỒồỔổỖỗỘộỚớỜờỞởỠỡỢợỤụỦủỨứỪừỬửỮữỰựỲỳỴỵỶỷỸỹ";
        static readonly string s0 = @"AAAAEEEIIOOOOUUYaaaaeeeiioooouuyAaDdIiUuOoUuAaAaAaAaAaAaAaAaAaAaAaAaEeEeEeEeEeEeEeEeIiIiOoOoOoOoOoOoOoOoOoOoOoOoUuUuUuUuUuUuUuYyYyYyYy";
        public static string RemoveDiacritics(string accentedStr)
        {
            List<char> list_char = new List<char>();
            foreach (var c in accentedStr)
            {
                var pos = s1.IndexOf(c);
                if (pos >= 0)
                {
                    list_char.Add(s0[pos]);
                }
                else
                {
                    list_char.Add(c);
                }
            }
            return new string(list_char.ToArray());
        }


        public static bool CreateFolder(string path_folder)
        {
            bool result = Directory.Exists(path_folder);
            if (!result)
            {
                Directory.CreateDirectory(path_folder);
                result = Directory.Exists(path_folder);
            }
            return result;
        }
        public static string GenerateNameImage()
        {
            CreateFolder(MyDefine.path_save_images);
            return String.Format("{0}\\{1}.jpg", MyDefine.path_save_images, DateTime.Now.ToString("yyyyMMdd_hhmmss"));
        }

        public static void Save_BitMap(Bitmap bm)
        {
            string file_name = GenerateNameImage();
            bm.Save(file_name, ImageFormat.Jpeg);
            Console.WriteLine("Saved file {0}", file_name);
        }


        public static void Save_Mat(Mat m, string leading_name)
        {
            CreateFolder(MyDefine.path_save_images);
            string file_name = String.Format("{0}\\{1}_{2}.jpg", MyDefine.path_save_images, leading_name, DateTime.Now.ToString("yyyyMMdd_hhmmss"));

            var frameBitmap = BitmapConverter.ToBitmap(m);
            frameBitmap.Save(file_name, ImageFormat.Jpeg);
            Console.WriteLine("Saved file {0}", file_name);
        }


        public static List<string> Get_All_File_In_Folder(string path, bool debug = false)
        {
            List<string> list_files = null;
            try
            {
                string[] files_xxx = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
                list_files = new List<string>(files_xxx);

            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception {e.Message}");
            }


            if (debug)
            {
                foreach (var file in list_files)
                {
                    Console.WriteLine(file);
                }
            }
            return list_files;
        }

        public static bool IsImagePath(string path)
        {
            if (string.IsNullOrEmpty(path))
                return false;
            Regex regex = new Regex(MyDefine.regex_get_image_file);
            Match match = regex.Match(path);
            if (match.Success)
            {
                return true;
            }
            return false;
        }

        public static bool IsIPAddress(string ip)
        {
            if (string.IsNullOrEmpty(ip))
                return false;
            Regex regex = new Regex(MyDefine.regex_get_ip);
            Match match = regex.Match(ip);
            if (match.Success)
            {
                return true;
            }
            return false;
        }

        public static List<string> Filter_Software_Type(List<string> list_files, string type, bool debug = false)
        {
            List<string> list_files_filter = new List<string>();
            Regex regex = new Regex(type);

            foreach (var file in list_files)
            {
                Match match = regex.Match(file);
                if (match.Success)
                {
                    list_files_filter.Add(file);
                }
            }

            if (debug)
            {
                foreach (var file in list_files_filter)
                {
                    Console.WriteLine(file);
                }
            }
            return list_files_filter;
        }


        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
