
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

                CommentCEN commentCEN = new CommentCEN ();
                AttackMoveCEN attackMoveCEN = new AttackMoveCEN ();
                CardCEN cardCEN = new CardCEN ();

                //ATTACKS
                 
                //BUG ATTACKS
                int bugAttack1 = attackMoveCEN.New_("Arrastre nuclear", CardTypeEnum.Bug, "Se arrastra hasta el rival como un gusano y explota");
                //int bugAttack2 = attackMoveCEN.New_("", CardTypeEnum.Bug, "");
                 
                //DRAGON ATTACKS
                int dragonAttack1 = attackMoveCEN.New_("Lanzallamas", CardTypeEnum.Dragon, "Lanza fuego por la boca para intentar hacer ceniza al rival");
                int dragonAttack2 = attackMoveCEN.New_("Cola Dragon", CardTypeEnum.Dragon, "Golpe con la cola que hará caer a cualquier rival al que le aseste un golpe");
                 
                //ELECTRIC ATTACKS
                int electricAttack1 = attackMoveCEN.New_("Calambrazo", CardTypeEnum.Electric, "Chispazo que te electrocutará como no tengas cuidado");
                //int electricAttack2 = attackMoveCEN.New_("", CardTypeEnum.Electric, "");
                 
                //FIGHTING ATTACKS
                int fightingAttack1 = attackMoveCEN.New_("Puño fuerte", CardTypeEnum.Fighting, "Puñetazo muy duro y con mucha intensidad");
                int fightingAttack2 = attackMoveCEN.New_("Patadón", CardTypeEnum.Fighting, "Patada aeréa en el pecho");
                 
                //FIRE ATTACKS
                //int fireAttack1 = attackMoveCEN.New_("", CardTypeEnum.Fire, "");
                //int fireAttack2 = attackMoveCEN.New_("", CardTypeEnum.Fire, "");
                 
                //FLYING ATTACKS
                int flyingAttack1 = attackMoveCEN.New_("Caida libre", CardTypeEnum.Flying, "Caída desde el cielo que aplastará a tus rivales");
                //int flyingAttack2 = attackMoveCEN.New_("", CardTypeEnum.Flying, "");
                 
                //GHOST ATTACKS
                int ghostAttack1 = attackMoveCEN.New_("Invisibilidad", CardTypeEnum.Ghost, "Desaparición visual para sorprender al rival ya que no sabe por donde le van a atacar");
                //int ghostAttack2 = attackMoveCEN.New_("", CardTypeEnum.Ghost, "");
                 
                //GRASS ATTACKS
                int grassAttack1 = attackMoveCEN.New_("Modo Topo", CardTypeEnum.Grass, "Se escabulle debajo de tierra para sorprender al rival y atacarle");
                //int grassAttack2 = attackMoveCEN.New_("", CardTypeEnum.Grass, "");
                 
                //GROUND ATTACKS
                int groundAttack1 = attackMoveCEN.New_("Mascazo", CardTypeEnum.Ground, "Golpe impresionante que te hará quedar exhausto");
                //int groundAttack2 = attackMoveCEN.New_("", CardTypeEnum.Ground, "");
                    
                //ICE ATTACKS
                int iceAttack1 = attackMoveCEN.New_("Congelar", CardTypeEnum.Ice, "Congela al rival a través del vaho que expulsa por la boca ya que sale muy frío");
                //int iceAttack2 = attackMoveCEN.New_("", CardTypeEnum.Ice, "");
                 
                //NORMAL ATTACKS
                int normalAttack1 = attackMoveCEN.New_("Placaje", CardTypeEnum.Normal, "Placaje con todo el cuerpo que puede llegar a tirar al rival");
                //int normalAttack2 = attackMoveCEN.New_("", CardTypeEnum.Normal, "");
                 
                //POISON ATTACKS
                int poisonAttack1 = attackMoveCEN.New_("Vino maldito", CardTypeEnum.Poison, "Bebida con buena apariencia que al final no es lo que parece");
                int poisonAttack2 = attackMoveCEN.New_("Gas Fatídico", CardTypeEnum.Poison, "Gas putrefacto que ahogará a cualquier rival que lo inhale");
                 
                //PSYCHIC ATTACKS
                int psychicAttack1 = attackMoveCEN.New_("Mareo", CardTypeEnum.Psychic, "Aturde al contrario con un gas tóxico");
                int psychicAttack2 = attackMoveCEN.New_("Pesao", CardTypeEnum.Psychic, "Ser pesado es una cualidad que no muchos manejan");
                 
                //ROCK ATTACKS
                int rockAttack1 = attackMoveCEN.New_("Pedrolo", CardTypeEnum.Rock, "Lanza una piedra muy grande que aplasta al rival");
                //int rockAttack2 = attackMoveCEN.New_("", CardTypeEnum.Rock, "");
                 
                //WATER ATTACKS
                int waterAttack1 = attackMoveCEN.New_("Manguerazo", CardTypeEnum.Water, "Torrente de agua muy potente");
                //int waterAttack2 = attackMoveCEN.New_("", CardTypeEnum.Water, "");
                 
                
                
                //CARDS
                 
                //BUG CARDS
                int bugCard1 = cardCEN.New_ ("Worms", "Parecen adorables pero controlan las armas que da gusto...", 4700, "worm.png", CardTypeEnum.Bug, 25, 40, 36, 10, RarityEnum.Basic, new List<int> { groundAttack1, grassAttack1, bugAttack1 });
                   
                //DRAGON CARDS
                 
                //ELECTRIC CARDS
                int electricCard1 = cardCEN.New_ ("Jhony chispas", "Electrocutado por un cable", 400, "jhonyChispas.png", CardTypeEnum.Electric, 10, 20, 10, 10, RarityEnum.Mythical, new List<int> { normalAttack1, electricAttack1, fightingAttack2 });
                int electricCard2 = cardCEN.New_ ("Cable pelao", "Tremendo cable pelao ", 2000, "cablePelao.png", CardTypeEnum.Electric, 100, 90, 50, 70, RarityEnum.Mythical, new List<int> { normalAttack1, electricAttack1, fightingAttack2 });
                 
                //FIGHTING CARDS
                int fightingCard1 = cardCEN.New_ ("Tri-Spiddie", "Que Spiderman será el real", 4700, "memeSpiderman.png", CardTypeEnum.Fighting, 25, 40, 36, 10, RarityEnum.Basic, new List<int> { flyingAttack1, normalAttack1, fightingAttack2 });
                 
                //FIRE CARDS
                                 
                //FLYING CARDS
                int flyingCard1 = cardCEN.New_ ("Mosca mutante", "Mitad mosca, mitad hombre. Se dice que está mutando como el de la mosca", 2500, "fly.png", CardTypeEnum.Flying, 39, 21, 18, 36, RarityEnum.Uncommon, new List<int> { flyingAttack1, groundAttack1, psychicAttack2 });
                int flyingCard2 = cardCEN.New_ ("Perro motociclón", "Rápido como el viento y más fuerte que un camión, aquí tenemos al perro motociclón", 4700, "perroMotociclon.png", CardTypeEnum.Flying, 66, 12, 90, 23, RarityEnum.Basic, new List<int> { normalAttack1, groundAttack1, psychicAttack1 });
                 
                //GHOST CARDS
                int ghostCard1 = cardCEN.New_ ("La dama gorda", "Un Fantasma que va rondando castillos.", 4700, "damaGorda.png", CardTypeEnum.Ghost, 25, 40, 36, 10, RarityEnum.Basic, new List<int> { iceAttack1, poisonAttack2, fightingAttack1 });
                 
                 
                //GRASS CARDS
                int grassCard1 = cardCEN.New_ ("El Diego", "Una especie de Dios argentino. Se le da bien eso del fútbol", 4700, "eldiego.png", CardTypeEnum.Grass, 55, 60, 18, 48, RarityEnum.Legendary, new List<int> { grassAttack1, fightingAttack2, psychicAttack1 });
                                 
                //GROUND CARDS
                int groundCard1 = cardCEN.New_ ("Jonhymelavo", "El Jonhy. De calle. Va más doblado que una salchicha doblada", 4700, "rakitic.png", CardTypeEnum.Ground, 25, 40, 36, 10, RarityEnum.Basic, new List<int> { groundAttack1, fightingAttack1, fightingAttack2 });
                int groundCard2 = cardCEN.New_ ("Baby Yoda", "Más pequeño que un átomo. Cuidado que se enfada.", 8000, "babyYoda.png", CardTypeEnum.Ground, 30, 60, 40, 10, RarityEnum.Legendary, new List<int> { grassAttack1, ghostAttack1, groundAttack1 });
                 
                //ICE CARDS
                int iceCard1 = cardCEN.New_ ("Papa Noel", "Regalos para todos", 400, "noel.png", CardTypeEnum.Ice, 10, 20, 10, 10, RarityEnum.Legendary, new List<int> { normalAttack1, electricAttack1, fightingAttack2 });
                                  
                //NORMAL CARDS
                int normalCard1 = cardCEN.New_("Perro panson", "Todo chiquito, todo panson", 1000, "", CardTypeEnum.Normal, 30, 10, 25, 10, RarityEnum.Basic, new List<int> { });
                int normalCard2 = cardCEN.New_ ("Mortadelo", "Personaje cómico que te sucumbe con su labia y sus bromas", 3200, "mortadelo.png", CardTypeEnum.Normal, 46, 24, 18, 30, RarityEnum.Rare, new List<int> { fightingAttack1, fightingAttack2, psychicAttack1 });
                 
                //POISON CARDS
                 
                //PSYCHIC CARDS
                 
                //ROCK CARDS
                 
                //WATER CARDS
                int waterCard1 = cardCEN.New_ ("Jack Sparrago", "El pirata más temido de todo poniente", 4700, "jack.png", CardTypeEnum.Water, 25, 40, 36, 10, RarityEnum.Basic, new List<int> { ghostAttack1, psychicAttack2, waterAttack1 });

                //BASE PACKS
                PackCEN packCEN = new PackCEN ();

                packCEN.New_ ("Sobre Básico Pequeño", "Sobre que contiene entre 1 y 5 cartas básicas", 100, "", RarityEnum.Basic, 1, 5, CardTypeEnum.All, RarityEnum.Basic);
                packCEN.New_ ("Sobre Básico Mediano", "Sobre que contiene entre 5 y 10 cartas básicas", 300, "", RarityEnum.Basic, 5, 10, CardTypeEnum.All, RarityEnum.Basic);
                packCEN.New_ ("Sobre Básico Grande", "Sobre que contiene entre 10 y 15 cartas básicas", 500, "", RarityEnum.Basic, 10, 15, CardTypeEnum.All, RarityEnum.Basic);

                packCEN.New_ ("Sobre Común Pequeño", "Sobre que contiene entre 1 y 5 cartas básicas y comunes", 150, "", RarityEnum.Common, 1, 5, CardTypeEnum.All, RarityEnum.Basic | RarityEnum.Common);
                packCEN.New_ ("Sobre Común Mediano", "Sobre que contiene entre 5 y 10 cartas básicas y comunes", 350, "", RarityEnum.Common, 5, 10, CardTypeEnum.All, RarityEnum.Basic | RarityEnum.Common);
                packCEN.New_ ("Sobre Común Grande", "Sobre que contiene entre 10 y 15 cartas básicas y comunes", 550, "", RarityEnum.Common, 10, 15, CardTypeEnum.All, RarityEnum.Basic | RarityEnum.Common);

                packCEN.New_ ("Sobre Poco Común Pequeño", "Sobre que contiene entre 1 y 5 cartas básicas, comunes y poco comunes", 200, "", RarityEnum.Uncommon, 1, 5, CardTypeEnum.All, RarityEnum.Basic | RarityEnum.Common | RarityEnum.Uncommon);
                packCEN.New_ ("Sobre Poco Común Mediano", "Sobre que contiene entre 5 y 10 cartas básicas, comunes y poco comunes", 400, "", RarityEnum.Uncommon, 5, 10, CardTypeEnum.All, RarityEnum.Basic | RarityEnum.Common | RarityEnum.Uncommon);
                packCEN.New_ ("Sobre Poco Común Grande", "Sobre que contiene entre 10 y 15 cartas básicas, comunes y poco comunes", 600, "", RarityEnum.Uncommon, 10, 15, CardTypeEnum.All, RarityEnum.Basic | RarityEnum.Common | RarityEnum.Uncommon);

                packCEN.New_ ("Sobre Raro Pequeño", "Sobre que contiene entre 1 y 5 cartas básicas, comunes, poco comunes y raras", 250, "", RarityEnum.Rare, 1, 5, CardTypeEnum.All, RarityEnum.Basic | RarityEnum.Common | RarityEnum.Uncommon | RarityEnum.Rare);
                packCEN.New_ ("Sobre Raro Mediano", "Sobre que contiene entre 5 y 10 cartas básicas, comunes, poco comunes y raras", 450, "", RarityEnum.Rare, 5, 10, CardTypeEnum.All, RarityEnum.Basic | RarityEnum.Common | RarityEnum.Uncommon | RarityEnum.Rare);
                packCEN.New_ ("Sobre Raro Grande", "Sobre que contiene entre 10 y 15 cartas básicas, comunes, poco comunes y raras", 650, "", RarityEnum.Rare, 10, 15, CardTypeEnum.All, RarityEnum.Basic | RarityEnum.Common | RarityEnum.Uncommon | RarityEnum.Rare);

                packCEN.New_ ("Sobre Épico Pequeño", "Sobre que contiene entre 1 y 5 cartas comunes, poco comunes, raras y épicas", 300, "", RarityEnum.Epic, 1, 5, CardTypeEnum.All, RarityEnum.Common | RarityEnum.Uncommon | RarityEnum.Rare | RarityEnum.Epic);
                packCEN.New_ ("Sobre Épico Mediano", "Sobre que contiene entre 5 y 10 cartas comunes, poco comunes, raras y épicas", 500, "", RarityEnum.Epic, 5, 10, CardTypeEnum.All, RarityEnum.Common | RarityEnum.Uncommon | RarityEnum.Rare | RarityEnum.Epic);
                packCEN.New_ ("Sobre Épico Grande", "Sobre que contiene entre 10 y 15 cartas comunes, poco comunes, raras y épicas", 700, "", RarityEnum.Epic, 10, 15, CardTypeEnum.All, RarityEnum.Common | RarityEnum.Uncommon | RarityEnum.Rare | RarityEnum.Epic);

                packCEN.New_ ("Sobre Legendario Pequeño", "Sobre que contiene entre 1 y 5 cartas poco comunes, raras, épicas y legendarias", 350, "", RarityEnum.Legendary, 1, 5, CardTypeEnum.All, RarityEnum.Uncommon | RarityEnum.Rare | RarityEnum.Epic | RarityEnum.Legendary);
                packCEN.New_ ("Sobre Legendario Mediano", "Sobre que contiene entre 5 y 10 cartas poco comunes, raras, épicas y legendarias", 550, "", RarityEnum.Legendary, 5, 10, CardTypeEnum.All, RarityEnum.Uncommon | RarityEnum.Rare | RarityEnum.Epic | RarityEnum.Legendary);
                packCEN.New_ ("Sobre Legendario Grande", "Sobre que contiene entre 10 y 15 cartas poco comunes, raras, épicas y legendarias", 750, "", RarityEnum.Legendary, 10, 15, CardTypeEnum.All, RarityEnum.Uncommon | RarityEnum.Rare | RarityEnum.Epic | RarityEnum.Legendary);

                packCEN.New_ ("Sobre Mítico Pequeño", "Sobre que contiene entre 1 y 5 cartas raras, épicas, legendarias y míticas", 400, "", RarityEnum.Mythical, 1, 5, CardTypeEnum.All, RarityEnum.Rare | RarityEnum.Epic | RarityEnum.Legendary | RarityEnum.Mythical);
                packCEN.New_ ("Sobre Mítico Mediano", "Sobre que contiene entre 5 y 10 cartas raras, épicas, legendarias y míticas", 600, "", RarityEnum.Mythical, 5, 10, CardTypeEnum.All, RarityEnum.Rare | RarityEnum.Epic | RarityEnum.Legendary | RarityEnum.Mythical);
                packCEN.New_ ("Sobre Mítico Grande", "Sobre que contiene entre 10 y 15 cartas raras, épicas, legendarias y míticas", 800, "", RarityEnum.Mythical, 10, 15, CardTypeEnum.All, RarityEnum.Rare | RarityEnum.Epic | RarityEnum.Legendary | RarityEnum.Mythical);

                
                //VIRTUALUSERS y USER CARD
                VirtualUserCEN virtualUserCEN = new VirtualUserCEN ();
                int virtualUser1 = virtualUserCEN.New_ ("Pass", "Usuario 1", "email@gmail.com");
                int virtualUser2 = virtualUserCEN.New_ ("Pass", "Usuario 2", "email1@gmail.com");
                int virtualUser3 = virtualUserCEN.New_ ("virtualUser12345", "Pepito123", "Pepito123@email.com");
                int virtualUser4 = virtualUserCEN.New_ ("virtualUser12345", "Juan123", "Juan123@email.com");

                //COMMENTS
                commentCEN.Publish ("El gusano está bastante bien", bugCard1, virtualUser1);
                commentCEN.Publish ("Guapisima esta carta amigo", bugCard1, virtualUser2);
                commentCEN.Publish ("Me gusta esta carta bastante", bugCard1, virtualUser3);

                commentCEN.Publish ("Ojala casarme con esta carta", electricCard2, virtualUser1);
                commentCEN.Publish ("Me gustaría comprarla, pero no tengo dinero :(", electricCard2, virtualUser2);
                commentCEN.Publish ("Me gusta esta carta bastante", electricCard2, virtualUser3);

                commentCEN.Publish ("La carta de Dios no falla", grassCard1, virtualUser1);
                commentCEN.Publish ("Menudo genio", grassCard1, virtualUser2);
                commentCEN.Publish ("Esta carta es increible, ¡me encanta!", grassCard1, virtualUser3);


                //TOKEN PACKS
                TokenPackCEN tokenPackCEN = new TokenPackCEN ();

                tokenPackCEN.New_("Pack Básico Pequeño", 1.0, 100);
                tokenPackCEN.New_("Pack Top Pequeño", 2.5, 240);
                tokenPackCEN.New_("Pack Básico Mediano", 5.0, 700);
                tokenPackCEN.New_("Pack Top Mediano", 10.0, 1450);
                tokenPackCEN.New_("Pack Básico Grande", 25.0, 3700);
                tokenPackCEN.New_("Pack Top Grande", 50.0, 7450);
                tokenPackCEN.New_("Pack Básico Gigante", 100.0, 14950);
                tokenPackCEN.New_("Pack Top Gigante", 200.0, 29950);

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
