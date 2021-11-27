
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckGenNHibernate.CEN.VirtualDeck;
using VirtualDeckGenNHibernate.CAD.VirtualDeck;
using VirtualDeckGenNHibernate.Enumerated.VirtualDeck;
using VirtualDeckGenNHibernate.CP.VirtualDeck;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                // Insert the initilizations of entities using the CEN classes

                //RESUMEN DE LO IMPLEMENTADO
                Console.WriteLine ("\nRESUMEN DE LO IMPLEMENTADO");
                Console.WriteLine ("--------------------------");
                Console.WriteLine ("FILTROS:");
                Console.WriteLine (" +Card");
                Console.WriteLine ("    -cardsByNameOrDescription");
                Console.WriteLine ("    -cardsByType");
                Console.WriteLine ("    -cardsByRarity");
                Console.WriteLine ("    -cardsByPrice");
                Console.WriteLine ();
                Console.WriteLine (" +Pack");
                Console.WriteLine ("    -packsByNameOrDescription");
                Console.WriteLine ("    -packsByType");
                Console.WriteLine ();
                Console.WriteLine (" +UserCard");
                Console.WriteLine ("    -userCardsByName");
                Console.WriteLine ("    -userCardsByBaseCard");
                Console.WriteLine ("    -userCardsByUser");
                Console.WriteLine ();
                Console.WriteLine (" +UserPack");
                Console.WriteLine ("    -userPacksByUser");
                Console.WriteLine ();
                Console.WriteLine (" +TradeOff");
                Console.WriteLine ("    -tradesByCardName");
                Console.WriteLine ();
                Console.WriteLine (" +VirtualUser");
                Console.WriteLine ("    -userByName");
                Console.WriteLine ();
                Console.WriteLine ();
                Console.WriteLine ("CUSTOMS:");
                Console.WriteLine (" +Bill");
                Console.WriteLine ("    -BillCEN_CreateAssociateProduct");
                Console.WriteLine ("    -BillCEN_CreateAssociateToken");
                Console.WriteLine ();
                Console.WriteLine (" +Comment");
                Console.WriteLine ("    -CommentCEN_Publish");
                Console.WriteLine ();
                Console.WriteLine (" +Pack");
                Console.WriteLine ("    -PackCEN_New_");
                Console.WriteLine ();
                Console.WriteLine (" +TradeOff");
                Console.WriteLine ("    -TradeOffCEN_Publish");
                Console.WriteLine ();
                Console.WriteLine (" +UserCard");
                Console.WriteLine ("    -UserCardCEN_New_");
                Console.WriteLine ();
                Console.WriteLine (" +UserPack");
                Console.WriteLine ("    -UserPackCEN_New_");
                Console.WriteLine ();
                Console.WriteLine (" +VirtualUser");
                Console.WriteLine ("    -VirtualUserCEN_New_");
                Console.WriteLine ("    -VirtualUserCEN_SearchCombat");
                Console.WriteLine ();
                Console.WriteLine ();
                Console.WriteLine ("CUSTOM TRANSACTIONS:");
                Console.WriteLine (" +Card");
                Console.WriteLine ("    -CardCP_CreateUserCard");
                Console.WriteLine ("    -CardCP_PurchaseUserCard");
                Console.WriteLine ();
                Console.WriteLine (" +Pack");
                Console.WriteLine ("    -PackCP_CreateUserPack");
                Console.WriteLine ("    -PackCP_PurchaseUserPack");
                Console.WriteLine ();
                Console.WriteLine (" +TokenPack");
                Console.WriteLine ("    -TokenPackCP_PurchaseTokenPack");
                Console.WriteLine ();
                Console.WriteLine (" +UserCard");
                Console.WriteLine ("    -UserCardCP_DestroyCard");
                Console.WriteLine ();
                Console.WriteLine (" +UserPack");
                Console.WriteLine ("    -UserCardCP_OpenPack");
                Console.WriteLine ();

                //ATTACKS
                AttackMoveCEN attackMoveCEN = new AttackMoveCEN ();
                int idAttack1 = attackMoveCEN.New_ ("Cola draco", CardTypeEnum.Dragon);
                int idAttack2 = attackMoveCEN.New_ ("Defensa de acero", CardTypeEnum.Dragon);
                int idAttack3 = attackMoveCEN.New_ ("Torton gurdo", CardTypeEnum.Dragon);
                int idAttack4 = attackMoveCEN.New_ ("Torton", CardTypeEnum.Fighting);
                int idAttack5 = attackMoveCEN.New_ ("Bola eléctrica", CardTypeEnum.Fire);

                //BASE CARDS
                CardCEN cardCEN = new CardCEN ();
                int cartaPrueba = cardCEN.New_ ("El pepe nuevo 2", "Dragon antiguo basado en el choque del cielo y la tierra", 2000, "urlAlAImagen", CardTypeEnum.Dragon, 100, 90, 50, 70, CardRarityEnum.Mythical, new List<int> { idAttack1, idAttack2, idAttack3 });
                int cartaPrueba1 = cardCEN.New_ ("Sr Ogro", "Ogro bien vestido", 1600, "urlAlAImagen", CardTypeEnum.Normal, 70, 60, 80, 30, CardRarityEnum.Legendary, new List<int> { idAttack1, idAttack2, idAttack3 });
                int cartaPrueba2 = cardCEN.New_ ("Dasdingo", "Seeeeh colegaa", 1200, "urlAlAImagen", CardTypeEnum.Fighting, 60, 50, 60, 50, CardRarityEnum.Epic, new List<int> { idAttack1, idAttack2, idAttack3 });
                int cartaPrueba3 = cardCEN.New_ ("En-Zhot", "Dragon caido", 1000, "urlAlAImagen", CardTypeEnum.Dragon, 100, 20, 10, 100, CardRarityEnum.Rare, new List<int> { idAttack1, idAttack2, idAttack3 });
                int cartaPrueba4 = cardCEN.New_ ("AccesibleBot", "Robot muy accesible creado por Tim Berners Lee", 800, "urlAlAImagen", CardTypeEnum.Electric, 30, 40, 50, 60, CardRarityEnum.Uncommon, new List<int> { idAttack1, idAttack2, idAttack3 });
                int cartaPrueba5 = cardCEN.New_ ("Secuaz Arierep", "Prisionero de la 'Guerra de los 4 mares'", 600, "urlAlAImagen", CardTypeEnum.Ghost, 20, 30, 20, 40, CardRarityEnum.Common, new List<int> { idAttack1, idAttack2, idAttack3 });
                int cartaPrueba6 = cardCEN.New_ ("Token no fungible", "Literalmente un token no fungible", 400, "urlAlAImagen", CardTypeEnum.Ghost, 10, 20, 10, 10, CardRarityEnum.Basic, new List<int> { idAttack1, idAttack2, idAttack3 });

                int primero = cardCEN.New_ ("Card1", "Carta 1", 12, "card1.img", CardTypeEnum.Electric, 45, 23, 12, 34, CardRarityEnum.Epic, new List<int> { idAttack4 });
                int segundo = cardCEN.New_ ("Card2", "Carta 2", 5, "card2.img", CardTypeEnum.Bug, 4, 27, 2, 4, CardRarityEnum.Basic, new List<int> { idAttack4 });
                int tercero = cardCEN.New_ ("Card3", "Carta 3", 45, "card3.img", CardTypeEnum.Fire, 5, 2, 2, 90, CardRarityEnum.Common, new List<int> { idAttack4 });

                //BASE PACKS
                PackCEN packCEN = new PackCEN ();
                int idpack1 = packCEN.New_ ("pack1", "pack 1", 20, "foto", PackTypeEnum.Basic, 3, 4);
                int idpack2 = packCEN.New_ ("pack2", "pack 2", 21, "foto", PackTypeEnum.OnlyFire, 3, 4);
                int idpack3 = packCEN.New_ ("pack3", "pack 2", 22, "foto", PackTypeEnum.OnlyFire, 3, 4);
                int idpack4 = packCEN.New_ ("pack4", "pack 4", 23, "foto", PackTypeEnum.Rare, 3, 4);

                //VIRTUALUSERS y USER CARD
                VirtualUserCEN virtualUserCEN = new VirtualUserCEN ();
                int virtualUser1 = virtualUserCEN.New_ ("Pass", "Usuario 1", "email@gmail.com");
                int virtualUser2 = virtualUserCEN.New_ ("Pass", "Usuario 2", "email1@gmail.com");
                int virtualUser3 = virtualUserCEN.New_ ("virtualUser12345", "Pepito123", "Pepito123@email.com");
                int virtualUser4 = virtualUserCEN.New_ ("virtualUser12345", "Juan123", "Juan123@email.com");

                int card1 = cardCEN.New_ ("Pikachu", "Descripcion carta 1", 1000, "Path", VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum.Fighting,
                        100, 100, 50, 100, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardRarityEnum.Mythical, new List<int>() {
                                idAttack1
                        });

                int card2 = cardCEN.New_ ("Martin", "Descripcion carta 2", 10, "Path", VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardTypeEnum.Fighting,
                        100, 100, 50, 100, VirtualDeckGenNHibernate.Enumerated.VirtualDeck.CardRarityEnum.Mythical, new List<int>() {
                                idAttack1
                        });

                //HAY QUE IMPLEMENTAR EL CREATE USER CARD
                UserCardCEN userCardCEN = new UserCardCEN ();
                int ucard1 = userCardCEN.New_ (CardTypeEnum.Fighting, CardRarityEnum.Mythical,
                        100, 50, 100, 100, "Pikarchu", "", new List<int>() {
                                idAttack1
                        }, card1);

                userCardCEN.AssignUser (ucard1, virtualUser1);

                int ucard2 = userCardCEN.New_ (CardTypeEnum.Fighting, CardRarityEnum.Mythical,
                        100, 100, 50, 100, "Martin", "", new List<int>() {
                                idAttack1
                        }, card2);

                userCardCEN.AssignUser (ucard2, virtualUser2);










                //PUBLISHED TRADEOFFS
                TradeOffCEN tradeOffCEN = new TradeOffCEN ();
                tradeOffCEN.Publish (virtualUser1, card1, ucard1);
                tradeOffCEN.Publish (virtualUser2, card2, ucard2);






















                //BASE CARD FILTERS
                IList<CardEN> cardTypeList = cardCEN.CardsByType (CardTypeEnum.Dragon);
                IList<CardEN> cardRarityList = cardCEN.CardsByRarity (CardRarityEnum.Legendary);
                IList<CardEN> cardNameDescriptionList = cardCEN.CardsByNameOrDescription ("Card1");
                IList<CardEN> cardPriceList = cardCEN.CardsByPrice (12);
                Console.WriteLine ("\n");
                Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine ("+            FILTER: BASE CARD             +");
                Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++\n");
                Console.WriteLine ("Cartas de tipo dragon:");
                Console.WriteLine ("-------------------------------------------");
                foreach (CardEN card in cardTypeList) {
                        Console.WriteLine ("Nombre: " + card.Name);
                        Console.WriteLine ("Descripcion: " + card.Description);
                        Console.WriteLine ("Rareza: " + card.Rarity);
                        Console.WriteLine ("Tipo: " + card.Type);
                        Console.WriteLine ();
                }

                Console.WriteLine ("\n");

                Console.WriteLine ("Cartas de rareza legendary:");
                Console.WriteLine ("-------------------------------------------");
                foreach (CardEN card in cardRarityList) {
                        Console.WriteLine ("Nombre: " + card.Name);
                        Console.WriteLine ("Descripcion: " + card.Description);
                        Console.WriteLine ("Rareza: " + card.Rarity);
                        Console.WriteLine ("Tipo: " + card.Type);
                        Console.WriteLine ();
                }

                Console.WriteLine ("\n");

                Console.WriteLine ("Cartas por nombre o descripcion: (Card1)");
                Console.WriteLine ("-------------------------------------------");
                foreach (CardEN card in cardNameDescriptionList) {
                        Console.WriteLine ("Nombre: " + card.Name);
                        Console.WriteLine ("Description: " + card.Description);
                        Console.WriteLine ("Price: " + card.Price + " tokens");
                        Console.WriteLine ();
                }

                Console.WriteLine ("\n");

                Console.WriteLine ("Cartas por precio: (12)");
                Console.WriteLine ("-------------------------------------------");
                foreach (CardEN card in cardPriceList) {
                        Console.WriteLine ("Nombre: " + card.Name);
                        Console.WriteLine ("Description: " + card.Description);
                        Console.WriteLine ("Price: " + card.Price + " tokens");
                        Console.WriteLine ();
                }


                Console.WriteLine ("\n\n");

                //BASE PACKS FILTERS
                Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine ("+            FILTER: BASE PACK             +");
                Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++\n");
                Console.WriteLine ("Sobres por nombre o descripcion: pack 2");
                Console.WriteLine ("-------------------------------------------");
                IList<PackEN> packs = packCEN.PacksByNameOrDescription ("pack 2");

                foreach (PackEN pack in packs) {
                        Console.WriteLine ("Nombre: " + pack.Name);
                        Console.WriteLine ("Descripcion: " + pack.Description);
                        Console.WriteLine ("Tipo: " + pack.Type);
                        Console.WriteLine ("Maximo numero de cartas: " + pack.MaxNumCards);
                        Console.WriteLine ("Minimo numero de cartas: " + pack.MinNumCards);
                        Console.WriteLine ("Precio: " + pack.Price + " tokens");
                        Console.WriteLine ();
                }

                Console.WriteLine ("\n");

                Console.WriteLine ("Sobres por tipo: onlyfire");
                Console.WriteLine ("-------------------------------------------");
                IList<PackEN> packs1 = packCEN.PacksByType (PackTypeEnum.OnlyFire);

                foreach (PackEN pack in packs1) {
                        Console.WriteLine ("Nombre: " + pack.Name);
                        Console.WriteLine ("Descripcion: " + pack.Description);
                        Console.WriteLine ("Tipo: " + pack.Type);
                        Console.WriteLine ("Maximo numero de cartas: " + pack.MaxNumCards);
                        Console.WriteLine ("Minimo numero de cartas: " + pack.MinNumCards);
                        Console.WriteLine ("Precio: " + pack.Price + " tokens");
                        Console.WriteLine ();
                }

                Console.WriteLine ("\n\n");


                //USER CARDS FILTERS
                Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine ("+            FILTER: USER CARDS            +");
                Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++\n");

                Console.WriteLine ("Busqueda pikarchu");
                Console.WriteLine ("-------------------------------------------");
                foreach (var card in userCardCEN.UserCardsByName (virtualUser1, "pikarchu")) {
                        Console.WriteLine (card.Name);
                }

                Console.WriteLine ();
                Console.WriteLine ("Busqueda ar");
                Console.WriteLine ("-------------------------------------------");
                foreach (var card in userCardCEN.UserCardsByName (virtualUser2, "%ar%")) {
                        Console.WriteLine (card.Name);
                }

                Console.WriteLine ();
                Console.WriteLine ("Busqueda usuario incorrecto");
                Console.WriteLine ("-------------------------------------------");
                foreach (var card in userCardCEN.UserCardsByName (-1, "Martin")) {
                        Console.WriteLine (card.Name);
                }

                Console.WriteLine ();
                Console.WriteLine ("Busqueda Carta base 1");
                Console.WriteLine ("-------------------------------------------");
                foreach (var card in userCardCEN.UserCardsByBaseCard (virtualUser1, card1)) {
                        Console.WriteLine (card.Name);
                }

                Console.WriteLine ();
                Console.WriteLine ("Busqueda Carta base 2");
                Console.WriteLine ("-------------------------------------------");

                foreach (var card in userCardCEN.UserCardsByBaseCard (virtualUser2, card2)) {
                        Console.WriteLine (card.Name);
                }

                Console.WriteLine ();
                Console.WriteLine ("Busqueda usuario incorrecto");
                Console.WriteLine ("-------------------------------------------");

                foreach (var card in userCardCEN.UserCardsByBaseCard (-1, card1)) {
                        Console.WriteLine (card.Name);
                }

                Console.WriteLine ();
                Console.WriteLine ("Busqueda carta base incorrecta");
                Console.WriteLine ("-------------------------------------------");

                foreach (var card in userCardCEN.UserCardsByBaseCard (virtualUser1, -1)) {
                        Console.WriteLine (card.Name);
                }

                Console.WriteLine ("\n\n");


                //TRADEOFF FILTERS

                IList<TradeOffEN> tradeOffs = tradeOffCEN.TradesByCardName ("Pikarchu");
                Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine ("+     FILTER: TRADES POR NOMBRE DE CARTA   +");
                Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++\n");
                Console.WriteLine ("Intercambios por nombre de carta: (Pikarchu)");
                Console.WriteLine ("-------------------------------------------");


                foreach (var i in tradeOffs) {
                        Console.WriteLine ("ID: " + i.DesiredCard.Id);
                        Console.WriteLine ("Fecha: " + i.Date);

                        CardEN desiredCard = new CardCEN ().ReadOID (i.DesiredCard.Id);
                        Console.WriteLine ("Carta Deseada: " + desiredCard.Name);

                        UserCardEN offeredCard = new UserCardCEN ().ReadOID (i.OfferedUserCard.Id);
                        Console.WriteLine ("Carta Ofrecida: " + offeredCard.Name);
                }

                Console.WriteLine ("\n\n");



                //VIRUALUSER FILTERS
                Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine ("+           FILTER: VIRTUAL USERS          +");
                Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++\n");
                Console.WriteLine ("Usuario por nombre: (Pepito123)");
                Console.WriteLine ("-------------------------------------------");
                IList<VirtualUserEN> virtualUserList = virtualUserCEN.UserByName ("Pepito123");
                foreach (VirtualUserEN user in virtualUserList) {
                        Console.WriteLine ("Nombre: " + user.UserName);
                        Console.WriteLine ("Description: " + user.Description);
                        Console.WriteLine ("Tokens: " + user.Tokens);
                        Console.WriteLine ("img: " + user.Img);
                        Console.WriteLine ("Email: " + user.Email);
                        Console.WriteLine ("Combat Status: " + user.CombatStatus);
                        Console.WriteLine ();
                }
                Console.WriteLine ("\n\n");



                //CP: CREATE USER CARD
                Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine ("+          CP: CREATE USER CARD            +");
                Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++\n");

                CardEN baseCard1 = new CardCEN ().ReadOID (cartaPrueba);
                CardEN baseCard2 = new CardCEN ().ReadOID (cartaPrueba1);


                CardCP cardCP = new CardCP ();
                int userCardOID = cardCP.CreateUserCard (cartaPrueba, 1); //cartaPrueba es el oid de una carta
                int userCardOID1 = cardCP.CreateUserCard (cartaPrueba1, 1);
                UserCardEN userCardEN1 = userCardCEN.ReadOID (userCardOID);
                UserCardEN userCardEN2 = userCardCEN.ReadOID (userCardOID1);



                //IList<CardEN> baseCardList = new List<CardEN>() { baseCard1, baseCard2 };
                //IList<UserCardEN> userCardList = new List<UserCardEN>() { userCardEN1, userCardEN2 };

                printCards (baseCard1, userCardEN1);
                printCards (baseCard2, userCardEN2);

                void printCards (CardEN baseCard, UserCardEN userCardEN)
                {
                        Console.WriteLine ("CARTA BASE DE LA TIENDA");
                        Console.WriteLine ("-------------------------------------------");
                        Console.WriteLine ("Nombre: " + baseCard.Name);
                        Console.WriteLine ("Descripcion: " + baseCard.Description);
                        Console.WriteLine ("Precio: " + baseCard.Price + " tokens");
                        Console.WriteLine ("Rareza: " + baseCard.Rarity);
                        Console.WriteLine ("Tipo: " + baseCard.Type);
                        Console.WriteLine ("Vida: " + baseCard.Health);
                        Console.WriteLine ("Ataque: " + baseCard.Attack);
                        Console.WriteLine ("Defensa: " + baseCard.Defense);
                        Console.WriteLine ("Velocidad: " + baseCard.Speed);
                        Console.WriteLine ();

                        Console.WriteLine ("CARTA DEL USUARIO:");
                        Console.WriteLine ("-------------------------------------------");
                        Console.WriteLine ("Nombre: " + userCardEN.Name);
                        //Console.WriteLine("Descripcion: " + userCardEN.Card.Description);
                        Console.WriteLine ("Level: " + userCardEN.Level);
                        Console.WriteLine ("Fecha de compra: " + userCardEN.PurchaseDate);
                        Console.WriteLine ("Rareza: " + userCardEN.Rarity);
                        Console.WriteLine ("Tipo: " + userCardEN.Type);
                        Console.WriteLine ("Vida: " + userCardEN.Health);
                        Console.WriteLine ("Ataque: " + userCardEN.Attack);
                        Console.WriteLine ("Defensa: " + userCardEN.Defense);
                        Console.WriteLine ("Velocidad: " + userCardEN.Speed);
                        Console.WriteLine ("\n");
                }

                void printBaseCard (CardEN baseCard)
                {
                        Console.WriteLine ("CARTA BASE DE LA TIENDA");
                        Console.WriteLine ("-------------------------------------------");
                        Console.WriteLine ("Nombre: " + baseCard.Name);
                        Console.WriteLine ("Descripcion: " + baseCard.Description);
                        Console.WriteLine ("Precio: " + baseCard.Price + " tokens");
                        Console.WriteLine ("Rareza: " + baseCard.Rarity);
                        Console.WriteLine ("Tipo: " + baseCard.Type);
                        Console.WriteLine ("Vida: " + baseCard.Health);
                        Console.WriteLine ("Ataque: " + baseCard.Attack);
                        Console.WriteLine ("Defensa: " + baseCard.Defense);
                        Console.WriteLine ("Velocidad: " + baseCard.Speed);
                        Console.WriteLine ();
                }


                void printUserCards (UserCardEN userCardEN)
                {
                        Console.WriteLine ("CARTA DEL USUARIO:");
                        Console.WriteLine ("-------------------------------------------");
                        Console.WriteLine ("Nombre: " + userCardEN.Name);
                        //Console.WriteLine("Descripcion: " + userCardEN.Card.Description);
                        Console.WriteLine ("Level: " + userCardEN.Level);
                        Console.WriteLine ("Fecha de compra: " + userCardEN.PurchaseDate);
                        Console.WriteLine ("Rareza: " + userCardEN.Rarity);
                        Console.WriteLine ("Tipo: " + userCardEN.Type);
                        Console.WriteLine ("Vida: " + userCardEN.Health);
                        Console.WriteLine ("Ataque: " + userCardEN.Attack);
                        Console.WriteLine ("Defensa: " + userCardEN.Defense);
                        Console.WriteLine ("Velocidad: " + userCardEN.Speed);
                        Console.WriteLine ("\n");
                }



                Console.WriteLine ("\n\n");

                Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine ("+              CP: TOKEN PACK              +");
                Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++\n");

                TokenPackCP tokenPackCP = new TokenPackCP ();
                TokenPackCEN tokenPackCEN = new TokenPackCEN ();

                int tokenOID1 = tokenPackCEN.New_ ("twoPack", "twoPack.png", 20, "Contiene cartas random", 300);
                int tokenOID2 = tokenPackCEN.New_ ("threePack", "treePack.png", 10, "Contiene cartas random", 200);
                int tokenOID3 = tokenPackCEN.New_ ("fourPack", "fourPack.png", 5, "Contiene cartas random", 9000);
                int tokenOID4 = tokenPackCEN.New_ ("fivePack", "fivePack.png", 20, "Contiene cartas random", 12);

                VirtualUserEN usuarioAntesCompraToken = virtualUserCEN.ReadOID (virtualUser1);

                /* -------------- Antes de la compra --------------------*/
                Console.WriteLine ("ANTES DE LA COMPRA");
                Console.WriteLine ("-------------------------------------------");
                Console.WriteLine ("Nombre: " + usuarioAntesCompraToken.UserName);
                Console.WriteLine ("Email: " + usuarioAntesCompraToken.Email);
                Console.WriteLine ("Tokens: " + usuarioAntesCompraToken.Tokens);
                Console.WriteLine ();
                /* ----------------------------------------------------- */

                tokenPackCP.PurchaseTokenPack (tokenOID1, virtualUser1);
                tokenPackCP.PurchaseTokenPack (tokenOID2, virtualUser1);
                tokenPackCP.PurchaseTokenPack (tokenOID3, virtualUser1);
                tokenPackCP.PurchaseTokenPack (tokenOID4, virtualUser1);


                VirtualUserEN usuarioCompraToken = virtualUserCEN.ReadOID (virtualUser1);

                /* -------------- Despues de la compra --------------------*/
                Console.WriteLine ("DESPUES DE LA COMPRA");
                Console.WriteLine ("-------------------------------------------");
                Console.WriteLine ("Nombre: " + usuarioCompraToken.UserName);
                Console.WriteLine ("Email: " + usuarioCompraToken.Email);
                Console.WriteLine ("Tokens: " + usuarioCompraToken.Tokens);

                /* ----------------------------------------------------- */

                Console.WriteLine ("\n\n");

                Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine ("+                 CP: CARD                 +");
                Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++\n");
                Console.WriteLine ("VAMOS A COMPRAR CARTAS CON UN USUARIO QUE TIENE TOKENS\n");
                Console.WriteLine ("ANTES DE LA COMPRA:");
                Console.WriteLine ("-------------------------------------------");
                Console.WriteLine ("Nombre: " + usuarioCompraToken.UserName);
                Console.WriteLine ("Email: " + usuarioCompraToken.Email);
                Console.WriteLine ("Tokens: " + usuarioCompraToken.Tokens);
                Console.WriteLine ("\n");

                Console.WriteLine ("COMPRAMOS 2 CARTAS COMO ESTA:");
                Console.WriteLine ("-------------------------------------------");
                CardEN purchasedCard = new CardCEN ().ReadOID (cartaPrueba);
                printBaseCard (purchasedCard);
                cardCP.PurchaseUserCard (cartaPrueba, virtualUser1, 2);



                VirtualUserEN usuarioCompraCartas = virtualUserCEN.ReadOID (virtualUser1);

                /* -------------- Despues de la compra --------------------*/
                Console.WriteLine ("DESPUES DE LA COMPRA");
                Console.WriteLine ("-------------------------------------------");
                Console.WriteLine ("Nombre: " + usuarioCompraCartas.UserName);
                Console.WriteLine ("Email: " + usuarioCompraCartas.Email);
                Console.WriteLine ("Tokens: " + usuarioCompraCartas.Tokens);
                Console.WriteLine ("\n");

                Console.WriteLine ("CARTAS QUE TIENE EL USUARIO AHORA:");
                Console.WriteLine ("-------------------------------------------\n");
                IList<UserCardEN> purchasedUserCardList = userCardCEN.UserCardsByBaseCard (virtualUser1, cartaPrueba);
                foreach (UserCardEN card in purchasedUserCardList) {
                        printUserCards (card);
                }


                Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine ("+            CP: DESTROY USER CARD         +");
                Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++\n");


                UserCardEN usercardEN = userCardCEN.ReadOID (ucard1);
                CardEN cardEN = cardCEN.ReadOID (usercardEN.Card.Id);
                VirtualUserEN usuEN = virtualUserCEN.ReadOID (usercardEN.User.Id);

                /* -------------- Antes de la compra --------------------*/
                Console.WriteLine ("ANTES DEL DESCARTE");
                Console.WriteLine ("-------------------------------------------");
                Console.WriteLine ("Nombre: " + usuEN.UserName);
                Console.WriteLine ("Email: " + usuEN.Email);
                Console.WriteLine ("Tokens: " + usuEN.Tokens);
                Console.WriteLine ();
                /* ----------------------------------------------------- */



                /* -------------- Antes de la compra --------------------*/
                Console.WriteLine ("PRECIO DE LA CARTA");
                Console.WriteLine ("-------------------------------------------");
                Console.WriteLine ("Nombre: " + usercardEN.Name);
                Console.WriteLine ("Usuario al que pertenece: " + usuEN.UserName);
                Console.WriteLine ("Precio: " + cardEN.Price);
                Console.WriteLine ();
                /* ----------------------------------------------------- */

                UserCardCP userCardCP = new UserCardCP ();
                userCardCP.DestroyCard (ucard1);

                VirtualUserEN usu1descarte = virtualUserCEN.ReadOID (virtualUser1);

                /* -------------- Despues de la compra --------------------*/
                Console.WriteLine ("DESPUES DEL DESCARTE");
                Console.WriteLine ("-------------------------------------------");
                Console.WriteLine ("Nombre: " + usu1descarte.UserName);
                Console.WriteLine ("Email: " + usu1descarte.Email);
                Console.WriteLine ("Tokens: " + usu1descarte.Tokens);

                /* ----------------------------------------------------- */

                Console.WriteLine ("\n\n");

                int pack1 = packCEN.New_ ("Basico", "Descripcion", 500, "", PackTypeEnum.Basic, 5, 1);
                int pack2 = packCEN.New_ ("Raro", "Descripcion", 600, "", PackTypeEnum.Rare, 6, 3);
                int pack3 = packCEN.New_ ("Especial", "Descripcion", 700, "", PackTypeEnum.Special, 7, 4);
                int pack4 = packCEN.New_ ("Fuego", "Descripcion", 800, "", PackTypeEnum.OnlyFire, 8, 5);
                int pack5 = packCEN.New_ ("Hierba", "Descripcion", 900, "", PackTypeEnum.OnlyGrass, 10, 5);

                PackEN purchasedPack1 = new PackCEN ().ReadOID (pack1);

                Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine ("+                 CP: PACKS                +");
                Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++\n");

                //Console.WriteLine("EL USUARIO TIENE " + usu1descarte.UserPacks.Count + " SOBRES\n");

                Console.WriteLine ("Vamos a comprar 3 packs como este:");
                Console.WriteLine ("-------------------------------------------");
                Console.WriteLine ("Nombre: " + purchasedPack1.Name);
                Console.WriteLine ("Precio: " + purchasedPack1.Price + " tokens");
                Console.WriteLine ("Tipo: " + purchasedPack1.Type);
                Console.WriteLine ("Cartas minimas: " + purchasedPack1.MinNumCards);
                Console.WriteLine ("Cartas maximas: " + purchasedPack1.MaxNumCards);
                Console.WriteLine ();

                PackCP packCP = new PackCP ();
                IList<int> purchasedPackList = packCP.PurchaseUserPack (pack1, virtualUser1, 3);

                Console.WriteLine ("Vemos los sobres del usuario tras la compra:");
                Console.WriteLine ("-------------------------------------------");
                UserPackCEN userPackCEN = new UserPackCEN ();
                IList<UserPackEN> userPacksFromUserList = userPackCEN.UserPacksByUser (virtualUser1);
                foreach (UserPackEN pack in userPacksFromUserList) {
                        Console.WriteLine ("Sobre tipo: " + pack.Type);
                }
                Console.WriteLine ();

                Console.WriteLine ("Vemos que las cartas que tiene siguen siendo las que ha comprado antes:");
                Console.WriteLine ("-------------------------------------------------------------------------------------");
                IList<UserCardEN> userCardsFromUserList = userCardCEN.UserCardsByUser (virtualUser1);
                foreach (UserCardEN card in userCardsFromUserList) {
                        printUserCards (card);
                }



                VirtualUserEN usuTrasPacks = virtualUserCEN.ReadOID (virtualUser1);

                /* -------------- Despues de la compra --------------------*/
                Console.WriteLine ("DESPUES DE COMPRAR LOS SOBRES");
                Console.WriteLine ("-------------------------------------------");
                Console.WriteLine ("Nombre: " + usuTrasPacks.UserName);
                Console.WriteLine ("Email: " + usuTrasPacks.Email);
                Console.WriteLine ("Tokens: " + usuTrasPacks.Tokens);
                Console.WriteLine ();

                //Console.WriteLine("EL USUARIO AHORA TIENE " + usuTrasPacks.UserPacks.Count + " SOBRES");


                Console.WriteLine ("VAMOS AHORA A ABRIR UN SOBRE Y VER LAS CARTAS DEL USUARIO");
                Console.WriteLine ("-------------------------------------------");

                //QUIZA EL OPEN PACK SEA UN DESTROY y HAY QUE DEVOLVER EN PURCHASEUSERPACKS UN OID

                //UserPackEN userPackEN = new UserPackCEN().ReadOID(purchasedPackList[0]);

                UserPackCP userPackCP = new UserPackCP ();

                userPackCP.OpenPack (purchasedPackList [0]);


                IList<UserCardEN> userCardsFinal = userCardCEN.UserCardsByUser (virtualUser1);
                //FALTA MOSTRAR EL NUMERO DE CARTAS

                foreach (UserCardEN card in userCardsFinal) {
                        printUserCards (card);
                }



                Console.WriteLine ("\n\n");

                Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine ("+         BILLS : READ FILTER BY USER      +");
                Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++\n");

                BillCEN billCEN = new BillCEN ();
                IList<BillEN> billsEN = billCEN.BillsByUser (virtualUser1);
                VirtualUserEN virtUserEN = virtualUserCEN.ReadOID (virtualUser1);
                ProductCEN productCEN = new ProductCEN ();
                int num = 1;
                Console.WriteLine ("BILLS DEL USER (" + virtualUser1 + ")");
                Console.WriteLine ("-------------------------------------------");
                Console.WriteLine ("Nombre: " + virtUserEN.UserName);
                Console.WriteLine ("Tokens: " + virtUserEN.Tokens);
                Console.WriteLine ();

                foreach (var bill in billsEN) {
                        if (bill.Product != null) {
                                ProductEN productEN = productCEN.ReadOID (bill.Product.Id);
                                Console.WriteLine ("BILL nº " + num + "(" + bill.Id + ")");
                                Console.WriteLine ("-------------------------------------------");
                                if (productEN is PackEN)
                                        Console.WriteLine ("Tipo: Sobre");
                                else
                                        Console.WriteLine ("Tipo: Carta");
                                Console.WriteLine ("Fecha: " + bill.Date);
                                Console.WriteLine ("Cantidad: " + bill.Amount);
                                Console.WriteLine ("Nombre producto: " + productEN.Name);
                                Console.WriteLine ("Precio producto: " + productEN.Price);
                                Console.WriteLine ();
                        }
                        else{
                                TokenPackEN tokPackEN = tokenPackCEN.ReadOID (bill.TokenPack.Id);
                                Console.WriteLine ("BILL nº " + num + "(" + bill.Id + ")");
                                Console.WriteLine ("-------------------------------------------");
                                Console.WriteLine ("Tipo: TokenPack");
                                Console.WriteLine ("Fecha: " + bill.Date);
                                Console.WriteLine ("Cantidad: " + bill.Amount);
                                Console.WriteLine ("Nombre TokenPack: " + tokPackEN.Name);
                                Console.WriteLine ("Precio TokenPack: " + tokPackEN.Price);
                                Console.WriteLine ("Tokens TokenPack: " + tokPackEN.Tokens);
                                Console.WriteLine ();
                        }
                        num++;
                }






                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
