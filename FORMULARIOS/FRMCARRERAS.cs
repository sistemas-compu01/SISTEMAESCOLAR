﻿using System;
using System.Windows.Forms;
using System.Data;

namespace SISTEMAESCOLAR.FORMULARIOS
{
    public partial class FRMCARRERAS : Form
    {
        public FRMCARRERAS()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            CLASES.CLCARRERAS consultar = new CLASES.CLCARRERAS(byte.Parse(txtid.Text));
            CLASES.clconexion conexion = new CLASES.clconexion(consultar.CONSULTARI());
            ds = conexion.consultar();
            if (ds.Tables[0].Rows.Count > 0)
            {
                // MODIFICAR
                // txtnombre.Text = ds.Tables["Tabla"].Rows[0]["NOMBRE"].ToString();
                CLASES.CLCARRERAS MODIFICARCARRERA = new CLASES.CLCARRERAS(Convert.ToByte(txtid.Text), txtnombre.Text, true);
                conexion = new CLASES.clconexion(MODIFICARCARRERA.modificar());
                conexion.EJECUTAR();
            }
            else
            {
                //  MessageBox.Show("Lo siento, dato no encontrado");
                CLASES.CLCARRERAS GRABARCARRERA = new CLASES.CLCARRERAS(Convert.ToByte(txtid.Text), txtnombre.Text, true);
                conexion = new CLASES.clconexion(GRABARCARRERA.GRABAR());
                conexion.EJECUTAR();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            consultar();
        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            busca();
        }
        private void busca()
        {
            try
            {
                CLASES.CLCARRERAS G = new CLASES.CLCARRERAS();
                CLASES.clconexion con = new CLASES.clconexion();
                if (con.Execute(G.consultageneral(), 0) == true)
                {
                    if (con.FieldValue != "")
                    {
                        txtid.Text = con.FieldValue;
                        consultar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
        private void consultar()
        {
            DataSet ds = new DataSet();

            CLASES.CLCARRERAS consultar = new CLASES.CLCARRERAS(byte.Parse(txtid.Text));
            CLASES.clconexion conexion = new CLASES.clconexion(consultar.CONSULTARI());
            ds = conexion.consultar();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtnombre.Text = ds.Tables["Tabla"].Rows[0]["NOMBRE"].ToString();
            }
            else
                MessageBox.Show("Lo siento, dato no encontrado");
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            CLASES.CLCARRERAS consultar = new CLASES.CLCARRERAS(byte.Parse(txtid.Text));
            CLASES.clconexion conexion = new CLASES.clconexion(consultar.CONSULTARI());
            ds = conexion.consultar();
            if (ds.Tables[0].Rows.Count > 0)
            {
                // DAR DE BAJA
                // txtnombre.Text = ds.Tables["Tabla"].Rows[0]["NOMBRE"].ToString();
                CLASES.CLCARRERAS borrarCARRERA = new CLASES.CLCARRERAS(Convert.ToByte(txtid.Text), txtnombre.Text, true);
                conexion = new CLASES.clconexion(borrarCARRERA.ELIMINAR());
                conexion.EJECUTAR();
            }
            else
            {
                  MessageBox.Show("Lo siento, dato no encontrado");
               
            }
        }
    }
}
