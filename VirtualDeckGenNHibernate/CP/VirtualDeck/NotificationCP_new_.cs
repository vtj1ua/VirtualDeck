
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;
using VirtualDeckGenNHibernate.CEN.VirtualDeck;
using VirtualDeckGenNHibernate.Enumerated.VirtualDeck;
using System.Net;
using System.Net.Mail;



/*PROTECTED REGION ID(usingVirtualDeckGenNHibernate.CP.VirtualDeck_Notification_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace VirtualDeckGenNHibernate.CP.VirtualDeck
{
public partial class NotificationCP : BasicCP
{
public VirtualDeckGenNHibernate.EN.VirtualDeck.NotificationEN New_ (int p_user, TypeNotificationEnum p_type)
{
        /*PROTECTED REGION ID(VirtualDeckGenNHibernate.CP.VirtualDeck_Notification_new_) ENABLED START*/

        INotificationCAD notificationCAD = null;
        NotificationCEN notificationCEN = null;

        VirtualDeckGenNHibernate.EN.VirtualDeck.NotificationEN result = null;


        try
        {
                SessionInitializeTransaction ();
                notificationCAD = new NotificationCAD (session);
                notificationCEN = new  NotificationCEN (notificationCAD);

                int oid;
                //Initialized NotificationEN
                NotificationEN notificationEN;
                notificationEN = new NotificationEN ();


                if (p_user != -1) {
                        notificationEN.User = new VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN ();
                        notificationEN.User.Id = p_user;
                }

                notificationEN.Type = p_type;


                //Call to NotificationCAD

                oid = notificationCAD.New_ (notificationEN);
                result = notificationCAD.ReadOIDDefault (oid);

                //Obtener el usuario desde aqui y enviarle el correo
                //(Metelo dentro de otro try-catch, que si crashea lo de enviar la notificacion no se crea

                VirtualUserCAD virtualUserCAD = new VirtualUserCAD(session);
                VirtualUserCEN virtualUserCEN = new VirtualUserCEN(virtualUserCAD);
                VirtualUserEN virtualUserEN = virtualUserCEN.ReadOID(p_user);   // coges el usuarios de la base de datos 

                try
                {
                    string web = "https://virtualdeck.000webhostapp.com/img/logoAzul.png";
                    string body = "VirtualDeck";
                    string asunto = "Tienda de cartas virtuales";

                    if (TypeNotificationEnum.Bill == p_type)
                    {
                        
                        asunto = "Compra de producto";
                        body = "<div style=\"color: #fff; background: #000; width: 500px; height: 300px; text-align: center; padding-top: 1em; border-radius: .5em\">" +
                            "<img src = \"" + web + "\" alt = \"VirtualDeck\" style = \"width: 50px;\">" +

                                "<h1 style = \"color: #fff; margin-top: 0.1em;\">Compra realizada</h1>" +

                                "<hr style = \"color: #fff; background: #fff; width: 300px;\">" +

                                "<p style = \"color: #fff;\">¡Enhorabuena!</p>" +

                                "<p style = \"color: #fff;\">Se ha realizado la compra satisfactoriamente.</p>" +

                                "<p style = \"color: #fff;\">Ya puedes consultar tu nueva carta en el inventario.</p>" +

                                "<p style = \"color: #fff;\">Fecha de compra: " + DateTime.Now.ToString("dd/MM/yyyy") + "</p>" +
                            "</div>";
                    }
                    else
                    {
                        asunto = "Intercambio";
                        body = "<div style=\"color: #fff; background: #000; width: 500px; height: 300px; text-align: center; padding-top: 1em; border-radius: .5em\">" +
                            "<img src = \"" + web + "\" alt = \"VirtualDeck\" style = \"width: 50px;\">" +

                                "<h1 style = \"color: #fff; margin-top: 0.1em;\">Intercambio realizado</h1>" +

                                "<hr style = \"color: #fff; background: #fff; width: 300px;\">" +

                                "<p style = \"color: #fff;\">¡Enhorabuena!</p>" +

                                "<p style = \"color: #fff;\">El intercambio se ha realizado satisfactoriamente.</p>" +

                                "<p style = \"color: #fff;\">Ya puedes ver tu nueva carta en el inventario.</p>" +

                                "<p style = \"color: #fff;\">Fecha de intercambio: " + DateTime.Now.ToString("dd/MM/yyyy") + "</p>" +
                            "</div>";
                    }

                    MailMessage msj = new MailMessage();
                    SmtpClient cli = new SmtpClient();

                    msj.From = new MailAddress("VirtualDeckDSM@gmail.com");
                    msj.To.Add(new MailAddress(virtualUserEN.Email));

                    msj.Subject = asunto;
                    msj.Body = body;
                    msj.IsBodyHtml = true;

                    cli.Host = "smtp.gmail.com";
                    cli.Port = 587;
                    cli.Credentials = new NetworkCredential("VirtualDeckDSM@gmail.com", "virtualdeckcorreo123");
                    cli.EnableSsl = true;
                    cli.Send(msj);

                }
                catch (Exception ex2)
                {

                }

                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
