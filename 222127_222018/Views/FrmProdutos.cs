using _222127_222018.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _222127_222018.Views
{
    public partial class FrmProdutos : Form
    {
        Produto p;
        Categoria c;
        Marca m;

        public FrmProdutos()
        {
            InitializeComponent();
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            m = new Marca();
            c = new Categoria();
            cboMarcas.DataSource= m.Consultar();
            cboMarcas.DisplayMember = "marca";
            cboMarcas.ValueMember= "id";
            cboCategorias.DataSource = c.Consultar();
            cboCategorias.DisplayMember = "categoria";
            cboCategorias.ValueMember= "id";

            limpaControles();
            carregarGrid("");

            dgvProdutos.Columns["idCategoria"].Visible = false;
            dgvProdutos.Columns["idMarca"].Visible = false;
            dgvProdutos.Columns["foto"].Visible = false;
        }
        void limpaControles()
        {
            txtId.Clear();
            txtDescricao.Clear();
            cboCategorias.SelectedIndex = -1;
            cboMarcas.SelectedIndex = -1;
            txtVlrVenda.Clear();
            txtEstoque.Clear();
            picFoto.ImageLocation = "";
        }
        void carregarGrid(string pesquisa)
        {
            p = new Produto()
            {
                descricao = pesquisa
            };
            dgvProdutos.DataSource = p.Consultar();
        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdutos.RowCount > 0)
            {
                txtId.Text = dgvProdutos.CurrentRow.Cells["id"].Value.ToString();
                txtDescricao.Text = dgvProdutos.CurrentRow.Cells["descricao"].Value.ToString();
                cboCategorias.Text = dgvProdutos.CurrentRow.Cells["categoria"].Value.ToString();
                cboMarcas.Text = dgvProdutos.CurrentRow.Cells["marca"].Value.ToString();
                txtVlrVenda.Text = dgvProdutos.CurrentRow.Cells["valorVenda"].Value.ToString();
                txtEstoque.Text = dgvProdutos.CurrentRow.Cells["estoque"].Value.ToString();                
                picFoto.ImageLocation = dgvProdutos.CurrentRow.Cells["foto"].Value.ToString();
            }
        }

        private void picFoto_Click(object sender, EventArgs e)
        {
            ofdArquivo.InitialDirectory = "D:/fotos/clientes/";
            ofdArquivo.FileName = "";
            ofdArquivo.ShowDialog();
            picFoto.ImageLocation = ofdArquivo.FileName;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text == "") return;

            p = new Produto()
            {
                descricao = txtDescricao.Text,
                idCategoria = (int)cboCategorias.SelectedValue,
                idMarca = (int)cboMarcas.SelectedValue,
                valorVenda = double.Parse(txtVlrVenda.Text),
                estoque = double.Parse(txtEstoque.Text),
                foto = picFoto.ImageLocation
                
            };
            p.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            {
                if (txtId.Text == String.Empty) return;

                p = new Produto()
                {
                    id = int.Parse(txtId.Text),
                    descricao = txtDescricao.Text,
                    idCategoria = (int)cboCategorias.SelectedValue,
                    idMarca = (int)cboMarcas.SelectedValue,
                    valorVenda = double.Parse(txtVlrVenda.Text),
                    estoque = double.Parse(txtEstoque.Text),                    
                    foto = picFoto.ImageLocation                    
                };

                p.Alterar();

                limpaControles();
                carregarGrid("");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "") return;

            if (MessageBox.Show("Tem certeza que deseja excluir?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                p = new Produto()
                {
                    id = int.Parse(txtId.Text)
                };
                p.Excluir();

                limpaControles();
                carregarGrid("");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void brnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisar.Text);
        }
    }
}
