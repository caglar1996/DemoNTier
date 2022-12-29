using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repo.Interfaces;
using Repo.Repositories;

namespace WindowsApp
{
    public partial class Form1 : Form
    {
        readonly string connectionString = "";
        public Form1()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            connectionString = configuration.GetConnectionString("DemoConnection");

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            using (IUserRepository userRepo = new UserRepository(new DemoContext(connectionString)))
            {
                var entity = userRepo.GetUser(1);
                Log("Name: " + entity.Name + " -  Age: " + entity.Age + " - " + entity.IsActive);
            }

        }

        private void Log(string msg)
        {
            if (listBox1.Items.Count > 1000)
                listBox1.Items.Clear();

            this.BeginInvoke((Action)delegate
            {
                listBox1.Items.Insert(0, msg);
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thr = new Thread(() => DemoShow());
            thr.Start();
        }

        public void DemoShow()
        {
            while (true)
            {
                using (IUserRepository userRepo = new UserRepository(new DemoContext(connectionString)))
                {
                    var entity = userRepo.GetUser(1);
                    Log("Name: " + entity.Name + " -  Age: " + entity.Age + " - " + entity.IsActive);
                }
                Thread.Sleep(2000);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (IUserRepository userRepo = new UserRepository(new DemoContext(connectionString)))
            {
                userRepo.UpdateUser(1, "Osman", 16);

            }
        }
    }
}