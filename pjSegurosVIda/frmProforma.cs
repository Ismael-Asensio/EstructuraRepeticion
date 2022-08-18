namespace pjSegurosVIda
{
    public partial class frmProforma : Form
    {
        public frmProforma()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //CAPTURANDO DATOS

            string razon = txtRazon.Text;
            string tipo = cbTipo.Text;
            int cantidad = int.Parse(txtCantidad.Text);

            //CALCULANDO EL PAGO MENSUAL POR TIPO DE SEGURO 

            double pagoMensual = 0;
            switch (tipo)
            {

                case "Inversion Clasica":
                    if (cantidad <= 10)
                        pagoMensual = 50 * cantidad;
                    else
                        pagoMensual = (50 * cantidad) + (10 * (cantidad - 10));
                    break;

                case "Inversion Platino":
                    if (cantidad <= 9)
                        pagoMensual = 80 * cantidad;
                    else
                        pagoMensual = (80 * cantidad) + (8 * (cantidad - 9));
                    break;

                case "Inversion Oro ":
                    if (cantidad <= 6)
                        pagoMensual = 150 * cantidad;
                    else
                        pagoMensual = (150 * cantidad) + (15 * (cantidad - 6));
                    break;


            }
            //IMPRIMIENDO EL DETALLE DE LA PROFORMA 

            ListViewItem fila = new ListViewItem(tipo);
            fila.SubItems.Add(cantidad.ToString());
            fila.SubItems.Add(pagoMensual.ToString("0.00"));
            lvPerformance.Items.Add(fila);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Seguro que te quieres salir del programa?",
                                             "CONTROL DE PROFORMAS",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
                this.Close();
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            //DETERMINAS EL TOTAL DE PERSONAS ASEGURADAS 

            int totalAsegurados = 0;
            for (int i = 0; i < lvPerformance.Items.Count; i++)
            {
                if (lvPerformance.Items[i].SubItems[0].Text != "");
                    totalAsegurados += int.Parse(lvPerformance.Items[i].SubItems[1].Text);
            }
            //DETERMINAR EL MONTO TOTAL ACUMULADO A CANCELAR 
            double total = 0;
            for(int i = 0; i < lvPerformance.Items.Count; i++)
            {
                if (lvPerformance.Items[i].SubItems[0].Text != "") ;
                total += double.Parse(lvPerformance.Items[i].SubItems[2].Text);
            }

            //IMPRESION DE LAS ESTADISTICAS 
            lvEstadistica.Items.Clear();
            string[] elementosFIla = new string[2];
            ListViewItem row;
            elementosFIla[0] = "Total de personas aseguradas";
            elementosFIla[1] = totalAsegurados.ToString();
            row = new ListViewItem(elementosFIla);
            lvEstadistica.Items.Add(row);

            elementosFIla[0] = "Monto total a cancelar";
            elementosFIla[1] = total.ToString("C");
            row = new ListViewItem(elementosFIla);
            lvEstadistica.Items.Add(row);


        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            DialogResult j = MessageBox.Show ("Estas seguro de anular la proforma?",
                                              "SEGUROS",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Exclamation);
            if (j == DialogResult.Yes)
            {
                txtRazon.Clear();
                cbTipo.Text="(SELECCIONE TIPO)";
                txtCantidad.Clear();
                txtRazon.Focus();
                lvPerformance.Items.Clear();
                lvEstadistica.Items.Clear();

            }
        }
    }
}