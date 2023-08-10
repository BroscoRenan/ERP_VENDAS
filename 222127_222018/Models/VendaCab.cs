using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace _222127_222018.Models
{
    public class VendaCab
    {
        public int id { get; set; }

        public int idCliente { get; set;}

        public DateTime data { get; set; }

        public double total { get; set; }

        public int Incluir()
        {

            try
            {
                //Abri conexão com o Banco de dados
                Banco.AbrirConexao();

                //Linguagem SQL para inserir dados no Banco
                Banco.Comando = new MySqlCommand("INSERT INTO VendaCab (idCliente, data, total) " +
                    "VALUES (@idCliente, @data, @total)", Banco.Conexao);

                //utiliza parâmetros em Nome e UF 
                Banco.Comando.Parameters.AddWithValue("@idCliente", idCliente);
                Banco.Comando.Parameters.AddWithValue("@data", data);
                Banco.Comando.Parameters.AddWithValue("@total", total);

                //executa o comando no Banco de Dados
                Banco.Comando.ExecuteNonQuery();

                //Fecha Conexão
                Banco.FecharConexao();

                return (int)Banco.Comando.LastInsertedId;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

        }

        public void Alterar()
        {
            try
            {
                //Abre conexão com o Banco de dados.
                Banco.AbrirConexao();

                //Comando em SQL para atualizar dados no Banco.
                Banco.Comando = new MySqlCommand();

                //Adiciona valores aos parâmetros.
                Banco.Comando.Parameters.AddWithValue("@idCliente", idCliente);
                Banco.Comando.Parameters.AddWithValue("@data", data);
                Banco.Comando.Parameters.AddWithValue("@total", total);



                //Executa o comando no Banco de Dados.
                Banco.Comando.ExecuteNonQuery();

                //Fecha Conexão.
                Banco.FecharConexao();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void Excluir()
        {
            try
            {
                //Abre conexão com o Banco de dados.
                Banco.AbrirConexao();

                //Comando em SQL para deletar dados no Banco.
                Banco.Comando = new MySqlCommand("delete from produtos where id = @id", Banco.Conexao);

                //Adiciona valores aos parâmetros.
                Banco.Comando.Parameters.AddWithValue("@id", id);

                //Executa o comando no Banco de Dados.
                Banco.Comando.ExecuteNonQuery();

                //Fecha Conexão.
                Banco.FecharConexao();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }

    
}
