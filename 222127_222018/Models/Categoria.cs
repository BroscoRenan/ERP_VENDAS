using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace _222127_222018.Models
{

    public class Categoria
    {
        public int id { get; set; }
        public string categoria { get; set; }

        public void Alterar()
        {
            try
            {
                //Abre conexão com o Banco de dados.
                Banco.AbrirConexao();

                //Comando em SQL para atualizar dados no Banco.
                Banco.Comando = new MySqlCommand("Update categorias set categoria = @categoria where id = @id", Banco.Conexao);

                //Adiciona valores aos parâmetros.
                Banco.Comando.Parameters.AddWithValue("@categoria", categoria);
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
                Banco.Comando = new MySqlCommand("delete from categorias where id = @id", Banco.Conexao);

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
                Banco.Comando = new MySqlCommand("INSERT INTO categorias (categoria) VALUES (@categoria)", Banco.Conexao);

                //utiliza parâmetros em marca 
                Banco.Comando.Parameters.AddWithValue("@categoria", categoria);

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
                Banco.Comando = new MySqlCommand("SELECT * FROM categorias where categoria like @categoria " +
                                                                    "order by categoria", Banco.Conexao);

                //Adiciona valores aos parâmetros.
                Banco.Comando.Parameters.AddWithValue("@categoria", categoria + "%");
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
