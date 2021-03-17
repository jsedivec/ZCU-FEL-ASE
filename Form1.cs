using System;
using System.Net;
using System.Text.Json;
using System.Windows.Forms;

namespace DU3_WS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Mzcr objekt;
        Data asd;
        private void Form1_Load(object sender, EventArgs e)
        {
            string s = String.Empty;
            using (WebClient clnt = new WebClient())
            {
                s = clnt.DownloadString("https://onemocneni-aktualne.mzcr.cz/api/v2/covid-19/testy-pcr-antigenni.json");
            }
            objekt = JsonSerializer.Deserialize<Mzcr>(s);
            asd = objekt.data[0];
            //comboBox1.Items.Add = asd.
            //MessageBox.Show(objekt.datum);
            /*foreach (var item in objekt.data)
            {
                MessageBox.Show("PCR_pozit_asymp: " + item.PCR_pozit_asymp + " " + item.datum);
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            string datum = dateTimePicker1.Value.ToString();
            datum = datum.Replace(".", "-");
            string[] datum1 = datum.Split(' ');
            datum1 = datum1[0].Split('-');
            string docasnaMesic = datum1[1];
            string docasnaRok = datum1[2];
            string docasnaDen = datum1[0];
            string datumFinal = docasnaRok + "-" + docasnaMesic + "-" + docasnaDen;
            for (int i = 0; i < objekt.data.Count; i++)
            {
                if (String.Equals(datumFinal, objekt.data[i].datum))
                {
                    VypisPodleData(i);
                    VypisPodleVyberu(comboBox1.Text);
                }
                else
                {
                    continue;
                }
            }
        }
        private void VypisPodleVyberu(string vyber)
        {
            String text = String.Empty;
            switch (vyber)
            {
                case "Počet PCR testů":
                    for (int i = objekt.data.Count - 1; i > objekt.data.Count - 20; i--)
                    {
                        listBox2.Items.Add(objekt.data[i].datum + " - " + objekt.data[i].pocet_PCR_testy);
                    }
                    break;
                case "Počet AG testů":
                    for (int i = objekt.data.Count - 1; i > objekt.data.Count - 20; i--)
                    {
                        listBox2.Items.Add(objekt.data[i].datum + " - " + objekt.data[i].pocet_PCR_testy);
                    }
                    break;
                case "PCR pozitivní symptotický":
                    for (int i = objekt.data.Count - 1; i > objekt.data.Count - 20; i--)
                    {
                        listBox2.Items.Add(objekt.data[i].datum + " - " + objekt.data[i].pocet_PCR_testy);
                    }
                    break;
                case "PCR pozitivní asymptotický":
                    for (int i = objekt.data.Count - 1; i > objekt.data.Count - 20; i--)
                    {
                        listBox2.Items.Add(objekt.data[i].datum + " - " + objekt.data[i].pocet_PCR_testy);
                    }
                    break;
                case "AG pozitivní symptotický":
                    for (int i = objekt.data.Count - 1; i > objekt.data.Count - 20; i--)
                    {
                        listBox2.Items.Add(objekt.data[i].datum + " - " + objekt.data[i].pocet_PCR_testy);
                    }
                    break;
                case "AG pozitivní asymptotický":
                    for (int i = objekt.data.Count - 1; i > objekt.data.Count - 20; i--)
                    {
                        listBox2.Items.Add(objekt.data[i].datum + " - " + objekt.data[i].pocet_PCR_testy);
                    }
                    break;
            }
        }

        private void VypisPodleData(int i)
        {
            String text = String.Format("Počet PCR: {0}", objekt.data[i].pocet_PCR_testy);
            listBox1.Items.Add(text);
            text = String.Format("Počet AG: {0}", objekt.data[i].pocet_AG_testy);
            listBox1.Items.Add(text);
            text = String.Format("Počet PCR pozitivních symptotických: {0}", objekt.data[i].PCR_pozit_sympt);
            listBox1.Items.Add(text);
            text = String.Format("Počet PCR pozitivních asymptotických: {0}", objekt.data[i], objekt.data[i].PCR_pozit_asymp);
            listBox1.Items.Add(text);
            text = String.Format("Počet AG pozitivních symptotických: {0}", objekt.data[i].AG_pozit_symp);
            listBox1.Items.Add(text);
            text = String.Format("Počet AG pozitivních asymptotických: {0}", objekt.data[i].AG_pozit_asymp_PCR_conf);
            listBox1.Items.Add(text);
            float pomer = (float)(objekt.data[i].PCR_pozit_sympt + objekt.data[i].PCR_pozit_asymp +
                objekt.data[i].AG_pozit_symp + objekt.data[i].AG_pozit_asymp_PCR_conf) /
                (objekt.data[i].pocet_PCR_testy + objekt.data[i].pocet_AG_testy);
            text = String.Format("\nPoměr pozitivních testů: {0:0.##}%", pomer * 100);
            listBox1.Items.Add(text);
        }
    }
}
