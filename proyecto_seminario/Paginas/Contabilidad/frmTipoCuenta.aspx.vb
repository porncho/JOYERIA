﻿Imports Ext.Net
Public Class frmTipoCuenta
    Inherits System.Web.UI.Page


#Region "Variables Globales"
    Private _id As Long
    Private _accion As Int16
    Private _descripcion As String
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fLlenarGrid()
    End Sub


#Region "Metodos Directos"
    <DirectMethod> _
    Public Function fGuardar() As Integer
        Dim v_respuesta As Int16
        Dim v_acceso As New clsControladorTipoCuenta
        Select Case _accion
            Case clsComunes.Operacion_Registro.Nuevo
                v_respuesta = v_acceso.fIngresarTipoCuenta(txtDescripcion.Text)
            Case clsComunes.Operacion_Registro.Editar
                v_respuesta = v_acceso.fModificarTipoCuenta(_id, txtDescripcion.Text)
        End Select
        Return v_respuesta
    End Function
#End Region


#Region "Metodos Directos"
    <DirectMethod> _
    Public Sub fLlenarGrid()
        Dim v_datos As New clsControladorTipoCuenta
        stTipoCuenta.DataSource = v_datos.fListarTipoCuenta
        stTipoCuenta.DataBind()
    End Sub
   

   
    Private Sub fobtenerValoresQuerystring()
        Try
            If Request.QueryString.AllKeys.Contains("codigo") Then
                _id = Long.Parse(Request.QueryString("codigo").ToString)

            End If
            If Request.QueryString.AllKeys.Contains("descripcion") Then
                txtDescripcion.Text = Request.QueryString("descripcion").ToString
            End If
            If Request.QueryString.AllKeys.Contains("accion") Then
                _accion = Int16.Parse(Request.QueryString("accion").ToString)
            End If
        Catch ex As Exception
            Ext.Net.X.Msg.Alert("ERROR", ex.Message).Show()
        End Try
    End Sub

#End Region

End Class