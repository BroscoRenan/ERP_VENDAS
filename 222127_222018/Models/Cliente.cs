using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _222127_222018.Models
{
    public class Cliente
    {     
            public int id { get; set; }
            public string nome { get; set; }
            public int idCidade { get; set; }
            public DateTime dataNasc { get; set; }
            public double renda { get; set; }
            public string cpf { get; set; }
            public string foto { get; set; }
            public bool venda { get; set; }

            
            public void Excluir()
            {
                try
                {
                    //Abre conexão com o Banco de dados.
                    Banco.AbrirConexao();

                    //Comando em SQL para deletar dados no Banco.
                    Banco.Comando = new MySqlCommand("delete from clientes where id = @id", Banco.Conexao);

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

        public DataTable Consultar()
        {
            try
            {
                //Abre conexão com o Banco de dados.
                Banco.AbrirConexao();

                //Comando em SQL para consultar dados no Banco.
                Banco.Comando = new MySqlCommand("SELECT cl.*, ci.nome cidade, " +
                    "ci.uf FROM Clientes cl inner join Cidades ci on (ci.id = cl.idCidade) " +
                    "where cl.nome like ?Nome order by cl.nome", Banco.Conexao);

                //Adiciona valores aos parâmetros.
                Banco.Comando.Parameters.AddWithValue("@nome", nome + "%");
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
            public void Incluir()
            {

                try
                {
                    //Abri conexão com o Banco de dados
                    Banco.AbrirConexao();

                    //Linguagem SQL para inserir dados no Banco
                    Banco.Comando = new MySqlCommand("INSERT INTO clientes (nome, idCidade, dataNasc, renda, cpf, foto, venda) " +
                        "VALUES (@nome, @idCidade, @dataNasc, @renda, @cpf, @foto, @venda)", Banco.Conexao);

                    //utiliza parâmetros em Nome e UF 
                    Banco.Comando.Parameters.AddWithValue("@nome", nome);
                    Banco.Comando.Parameters.AddWithValue("@idCidade", idCidade);
                    Banco.Comando.Parameters.AddWithValue("@dataNasc", dataNasc);
                    Banco.Comando.Parameters.AddWithValue("@renda", renda);
                    Banco.Comando.Parameters.AddWithValue("@cpf", cpf);
                    Banco.Comando.Parameters.AddWithValue("@foto", foto);
                    Banco.Comando.Parameters.AddWithValue("@venda", venda);

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
        public void Alterar()
        {
            try
            {
                //Abre conexão com o Banco de dados.
                Banco.AbrirConexao();

                //Comando em SQL para atualizar dados no Banco.
                Banco.Comando = new MySqlCommand("Update clientes set nome = @nome, idCidade = @idCidade, dataNasc = @dataNasc, renda = @renda, cpf = @cpf, foto = @foto, venda = @venda where id = @id", Banco.Conexao);

                //Adiciona valores aos parâmetros.
                Banco.Comando.Parameters.AddWithValue("@nome", nome);
                Banco.Comando.Parameters.AddWithValue("@idCidade", idCidade);
                Banco.Comando.Parameters.AddWithValue("@dataNasc", Convert.ToDateTime(dataNasc.ToString("dd/MM/yyyy")));
                Banco.Comando.Parameters.AddWithValue("@renda", renda);
                Banco.Comando.Parameters.AddWithValue("@cpf", cpf);
                Banco.Comando.Parameters.AddWithValue("@foto", foto);
                Banco.Comando.Parameters.AddWithValue("@venda", venda);
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


