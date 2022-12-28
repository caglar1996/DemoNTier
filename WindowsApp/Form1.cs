using Repo.Interfaces;

namespace WindowsApp
{
    public partial class Form1 : Form
    {
        private readonly IUserRepository userRepository;

        Thread thrUser = null;
        public Form1(IUserRepository userRepository)
        {

            InitializeComponent();
            this.userRepository = userRepository;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
                var entity = userRepository.GetUser(1);
                Log("Name: " + entity.Name + " -  Age: " + entity.Age + " - " + entity.IsActive);

                Thread.Sleep(2000);
            }
        }
    }
}