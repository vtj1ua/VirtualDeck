

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using VirtualDeckGenNHibernate.Exceptions;

using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;


namespace VirtualDeckGenNHibernate.CEN.VirtualDeck
{
/*
 *      Definition of the class VirtualUserCEN
 *
 */
public partial class VirtualUserCEN
{
private IVirtualUserCAD _IVirtualUserCAD;

public VirtualUserCEN()
{
        this._IVirtualUserCAD = new VirtualUserCAD ();
}

public VirtualUserCEN(IVirtualUserCAD _IVirtualUserCAD)
{
        this._IVirtualUserCAD = _IVirtualUserCAD;
}

public IVirtualUserCAD get_IVirtualUserCAD ()
{
        return this._IVirtualUserCAD;
}

public void Modify (int p_VirtualUser_OID, String p_pass, string p_userName, string p_email, string p_description, int p_tokens, string p_img, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CombatStatusEnum p_combatStatus)
{
        VirtualUserEN virtualUserEN = null;

        //Initialized VirtualUserEN
        virtualUserEN = new VirtualUserEN ();
        virtualUserEN.Id = p_VirtualUser_OID;
        virtualUserEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        virtualUserEN.UserName = p_userName;
        virtualUserEN.Email = p_email;
        virtualUserEN.Description = p_description;
        virtualUserEN.Tokens = p_tokens;
        virtualUserEN.Img = p_img;
        virtualUserEN.CombatStatus = p_combatStatus;
        //Call to VirtualUserCAD

        _IVirtualUserCAD.Modify (virtualUserEN);
}

public void Destroy (int id
                     )
{
        _IVirtualUserCAD.Destroy (id);
}

public string Login (int p_VirtualUser_OID, string p_pass)
{
        string result = null;
        VirtualUserEN en = _IVirtualUserCAD.ReadOIDDefault (p_VirtualUser_OID);

        if (en != null && en.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = this.GetToken (en.Id);

        return result;
}

public VirtualUserEN ReadOID (int id
                              )
{
        VirtualUserEN virtualUserEN = null;

        virtualUserEN = _IVirtualUserCAD.ReadOID (id);
        return virtualUserEN;
}

public System.Collections.Generic.IList<VirtualUserEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<VirtualUserEN> list = null;

        list = _IVirtualUserCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<VirtualDeckGenNHibernate.EN.VirtualDeck.VirtualUserEN> UserByName (string p_userName)
{
        return _IVirtualUserCAD.UserByName (p_userName);
}



private string Encode (int id)
{
        var payload = new Dictionary<string, object>(){
                { "id", id }
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (int id)
{
        VirtualUserEN en = _IVirtualUserCAD.ReadOIDDefault (id);
        string token = Encode (en.Id);

        return token;
}
public int CheckToken (string token)
{
        int result = -1;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                int id = (int)ObtenerID (decodedToken);

                VirtualUserEN en = _IVirtualUserCAD.ReadOIDDefault (id);

                if (en != null && ((long)en.Id).Equals (ObtenerID (decodedToken))
                    ) {
                        result = id;
                }
                else throw new ModelException ("El token es incorrecto");
        } catch (Exception e)
        {
                throw new ModelException ("El token es incorrecto");
        }

        return result;
}


public long ObtenerID (string decodedToken)
{
        try
        {
                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object> >(decodedToken);
                long id = (long)results ["id"];
                return id;
        }
        catch
        {
                throw new Exception ("El token enviado no es correcto");
        }
}
}
}
