using _222127_222018.Models;
using System;
using System.Data;
using System.Windows.Forms;


namespace _222127_222018.Views
{
    public partial class FrmVendas : Form
    {
        double total;

        Cliente c;
        Produto p;
        VendaCab vc;
        VendaDet vd;

        public FrmVendas()
        {
            InitializeComponent();
        }

        private void FrmVendas_Load(object sender, EventArgs e)
        {
            c = new Cliente();
            cboClientes.DataSource = c.Consultar();
            cboClientes.DisplayMember= "Nome";
            cboClientes.ValueMember= "id";

            p = new Produto();
            cboProduto.DataSource = p.Consultar();
            cboProduto.DisplayMember = "descricao";
            cboProduto.ValueMember = "id";

            btnCancelar.PerformClick();
        }

        void limpaProduto()
        {
            cboProduto.SelectedIndex = -1;
            txtEstoque.Clear();
            txtPreco.Clear();
            txtQuantidade.Clear();
            txtMarca.Clear();
            txtCategoria.Clear();
            picProduto.ImageLocation = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgvProdutos.RowCount = 0;
            cboClientes.SelectedIndex = -1;
            txtCidade.Clear();
            txtUF.Clear();
            txtRenda.Clear();
            mskCPF.Clear();
            mskDataNasc.Clear();
            chkVenda.Checked = false;
            picCliente.ImageLocation = "";
            total = 0;
            lblTotal.Text = total.ToString("C");
            grbClientes.Enabled = true;
            grbProdutos.Enabled = false;
            limpaProduto();
        }

        private void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClientes.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboClientes.SelectedItem;
                txtCidade.Text = reg["CIDADE"].ToString();
                txtUF.Text = reg["UF"].ToString();
                txtRenda.Text = reg["RENDA"].ToString();
                mskCPF.Text = reg["CPF"].ToString();
                mskDataNasc.Text = reg["DATANASC"].ToString();
                picCliente.ImageLocation = reg["FOTO"].ToString();
                chkVenda.Checked = (bool)reg["VENDA"];
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cboClientes.SelectedIndex != -1)
            {
                if (chkVenda.Checked)
                {
                    MessageBox.Show("Cliente bloqueado para venda", "Vendas",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnCancelar.PerformClick();
                    return;
                }
                grbClientes.Enabled = false;
                grbProdutos.Enabled = true;
            }
        }

        private void cboProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProduto.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboProduto.SelectedItem;
                txtEstoque.Text = reg["estoque"].ToString();
                txtPreco.Text = reg["valorVenda"].ToString();
                txtMarca.Text = reg["Marca"].ToString();
                txtCategoria.Text = reg["Categoria"].ToString();                
                picProduto.ImageLocation = reg["foto"].ToString();
                
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            double qtde = double.Parse(txtQuantidade.Text);
            double estoque = double.Parse(txtEstoque.Text);

            if (qtde > estoque)
            {
                MessageBox.Show("Estoque insuficiente", "Vendas",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantidade.SelectAll();
                return;
            }

            dgvProdutos.Rows.Add(cboProduto.SelectedValue, cboProduto.Text,
                        txtQuantidade.Text, txtPreco.Text);

            double preco = double.Parse(txtPreco.Text);

            total += qtde * preco;
            lblTotal.Text = total.ToString("C");
            limpaProduto();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if(dgvProdutos.RowCount > 0)
            {
                double qtde = double.Parse(dgvProdutos.CurrentRow.Cells[2].Value.ToString());
                double preco = double.Parse(dgvProdutos.CurrentRow.Cells[3].Value.ToString());

                total -= qtde * preco;
                lblTotal.Text = total.ToString("C");

                dgvProdutos.Rows.RemoveAt(dgvProdutos.CurrentRow.Index);            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            vc = new VendaCab()
            {
                idCliente = (int)cboClientes.SelectedValue,
                data = DateTime.Now,
                total = total
            };

            int idVenda = vc.Incluir();

            foreach (DataGridViewRow linha in dgvProdutos.Rows)
            {
                vd = new VendaDet()
                {
                    idVendaCab = idVenda,
                    idProduto = Convert.ToInt32(linha.Cells[0].Value),
                    qtde = Convert.ToDouble(linha.Cells[2].Value),
                    valorUnitario = Convert.ToDouble(linha.Cells[3].Value)
                };

                vd.Incluir();

                p = new Produto()
                {
                    id = (int)linha.Cells[0].Value
                };
                p.atualizaEstoque(Convert.ToDouble(linha.Cells[2].Value));
            }

            btnCancelar.PerformClick();
        }

        private void picCliente_Click(object sender, EventArgs e)
        {
            ofdArquivo.InitialDirectory = "D:/fotos/clientes/";
            ofdArquivo.FileName = "";
            ofdArquivo.ShowDialog();
            picCliente.ImageLocation = ofdArquivo.FileName;
        }

        private void picProduto_Click(object sender, EventArgs e)
        {
            ofdArquivo.InitialDirectory = "D:/fotos/clientes/";
            ofdArquivo.FileName = "";
            ofdArquivo.ShowDialog();
            picProduto.ImageLocation = ofdArquivo.FileName;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
