﻿using System;
using System.Data;
using System.Windows.Forms;
using _222127_222018.Models;
using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace _222127_222018
{
    public class Banco
    {
        //Criando as variáveis públicas para conexão e consulta serão usadas em todo o projeto
        //Connection responsável pela conexão com o MySQL
        public static MySqlConnection Conexao;

        //Command responsável por inserir dados em um dataTable
        public static MySqlCommand Comando;

        //Adapter responsável por inserir dados em um dataTable
        public static MySqlDataAdapter Adaptador;

        //DataTable responsável por ligar o banco em controles com a propriedade DataSource
        public static DataTable datTabela;

        public static void AbrirConexao()
        {
            try
            {
                //Estabelece os parâmetros para a conexão com o banco
                Conexao = new MySqlConnection("server=localhost;port=3306;uid=root;pwd=R1e2n3a4n5!");

                Conexao.Open();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void FecharConexao()
        {
            try
            {
                //Fecha a conexão com o banco de dados 
                Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void CriarBanco()
        {
            try
            {
                //Chama a função para abertura de conexão com o banco
                AbrirConexao();

                //Informa a instrução SQL
                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS vendas; USE vendas", Conexao);

                //Executa a Querry no MySQL (Raio do WorkBench)
                Comando.ExecuteNonQuery();
                
                //Instrução para criar uma table
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Cidades" +
                                           "(id integer auto_increment primary key, " +
                                           "nome char(40), " +
                                           "uf char(02))", Conexao);
                Comando.ExecuteNonQuery();
                
                //Instrução para criar a tabela Marcas
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Marcas" +
                                           "(id integer auto_increment primary key, " +
                                           "marca char(20))", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Categorias" +
                                           "(id integer auto_increment primary key, " +
                                           "categoria char(20))", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Clientes" +
                                           "(id integer auto_increment primary key, " +
                                           "nome char(40), " +
                                           "idCidade integer," +
                                           "dataNasc date," +
                                           "renda decimal(10,2), " +
                                           "cpf char(14), " +
                                           "foto varchar(100)," +
                                           "venda boolean)", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Produtos" +
                                           "(id integer auto_increment primary key, " +
                                           "descricao char(40), " +
                                           "idCategoria integer," +
                                           "idMarca integer," +                                           
                                           "valorVenda decimal(10,2), " +
                                           "estoque decimal(10,3), " +
                                           "foto varchar(100))", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS VendaCab" +
                                           "(id integer auto_increment primary key, " +
                                           "idCliente int, " +
                                           "data date," +
                                           "total decimal(10,2))" , Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS VendaDet" +
                                           "(id integer auto_increment primary key, " +
                                           "idVendaCab int, " +
                                           "idProduto int, " +
                                           "qtde decimal(10,3)," +
                                           "valorUnitario decimal(10,2))", Conexao);
                Comando.ExecuteNonQuery();

                //Chama a função para a conexão com o banco
                FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
    
}

