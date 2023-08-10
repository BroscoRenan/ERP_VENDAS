using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;


namespace _222127_222018.Models
{
    public class Marca
    {
        public int id { get; set;  }
        public string marca { get; set; }

        public void Alterar()
        {
            try
            {
                //Abre conexão com o Banco de dados.
                Banco.AbrirConexao();

                //Comando em SQL para atualizar dados no Banco.
                Banco.Comando = new MySqlCommand("Update marcas set marca = @marca where id = @id", Banco.Conexao);

                //Adiciona valores aos parâmetros.
                Banco.Comando.Parameters.AddWithValue("@marca", marca);
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

        public void Excluir()
        {
            try
            {
                //Abre conexão com o Banco de dados.
                Banco.AbrirConexao();

                //Comando em SQL para deletar dados no Banco.
                Banco.Comando = new MySqlCommand("delete from marcas where id = @id", Banco.Conexao);

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

        public void Incluir()
        {

            try
            {
                //Abri conexão com o Banco de dados
                Banco.AbrirConexao();

                //Linguagem SQL para inserir dados no Banco
                Banco.Comando = new MySqlCommand("INSERT INTO marcas (marca) VALUES (@marca)", Banco.Conexao);

                //utiliza parâmetros em marca 
                Banco.Comando.Parameters.AddWithValue("@marca", marca);               

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

        public DataTable Consultar()
        {
            try
            {
                //Abre conexão com o Banco de dados.
                Banco.AbrirConexao();

                //Comando em SQL para consultar dados no Banco.
                Banco.Comando = new MySqlCommand("SELECT * FROM marcas where marca like @marca " +
                                                                    "order by marca", Banco.Conexao);

                //Adiciona valores aos parâmetros.
                Banco.Comando.Parameters.AddWithValue("@marca", marca + "%");
                Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
                Banco.datTabela = new DataTable();
                Banco.Adaptador.Fill(Banco.datTabela);
                Banco.FecharConexao();
                return Banco.datTabela;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

    }
}
