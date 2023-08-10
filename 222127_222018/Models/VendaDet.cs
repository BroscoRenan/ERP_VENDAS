using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace _222127_222018.Models
{
    public class VendaDet
    {
        public int id { get; set; }

        public int idVendaCab { get; set; }

        public int idProduto { get; set; }

        public double qtde { get; set; }

        public double valorUnitario { get; set; }

        public void Incluir()
        {

            try
            {
                //Abri conexão com o Banco de dados
                Banco.AbrirConexao();

                //Linguagem SQL para inserir dados no Banco
                Banco.Comando = new MySqlCommand("INSERT INTO VendaDet (idVendaCab, idProduto, qtde, valorUnitario) " +
                    "VALUES (@idVendaCab, @idProduto, @qtde, @valorUnitario)", Banco.Conexao);

                //utiliza parâmetros em Nome e UF 
                Banco.Comando.Parameters.AddWithValue("@idVendaCab", idVendaCab);
                Banco.Comando.Parameters.AddWithValue("@idProduto", idProduto);
                Banco.Comando.Parameters.AddWithValue("@qtde", qtde);
                Banco.Comando.Parameters.AddWithValue("@valorUnitario", valorUnitario);

                //executa o comando no Banco de Dados
                Banco.Comando.ExecuteNonQuery();

                //Fecha Conexão
                Banco.FecharConexao();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }



}
