
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
                int bugAttack1 = attackMoveCEN.New_("Picadura", CardTypeEnum.Bug, "Picadura causa da??o al objetivo con posibilidad de envenenar");
                int bugAttack2 = attackMoveCEN.New_("Pin misil", CardTypeEnum.Bug, "Pin misil causa da??o, golpeando al objetivo de 2 a 5 veces en un mismo turno");
                int bugAttack3 = attackMoveCEN.New_("Danza Aleteo", CardTypeEnum.Bug, "Danza aleteo aumenta el ataque, la defensa, y la velocidad del usuario");
                int bugAttack4 = attackMoveCEN.New_("Chupavidas", CardTypeEnum.Bug, "Chupavidas causa da??o y el usuario recupera el 50% del da??o realizado");
                int bugAttack5 = attackMoveCEN.New_("Bola de polen", CardTypeEnum.Bug, "Bola de polen causa da??o y no tiene ning??n efecto secundario");
                int bugAttack6 = attackMoveCEN.New_("Tijera X", CardTypeEnum.Bug, "Tijera X causa da??o y no tiene ning??n efecto secundario");
                int bugAttack7 = attackMoveCEN.New_("Viento plata", CardTypeEnum.Bug, "Viento plata causa da??o y tiene una probabilidad del 10% de subir el ataque y la defensa");
                int bugAttack8 = attackMoveCEN.New_("Zumbido", CardTypeEnum.Bug, "Zumbido es un movimiento de sonido que causa da??o y tiene una probabilidad del 10% de reducir un nivel la defensa al oponente");
                int bugAttack9 = attackMoveCEN.New_("Guada??a sedosa", CardTypeEnum.Bug, "Guada??a sedosa causa da??o y no tiene ning??n efecto secundario");
                int bugAttack10 = attackMoveCEN.New_("Megacuerno", CardTypeEnum.Bug, "Megacuerno causa da??o y no tiene ning??n efecto secundario");

                //DRAGON ATTACKS
                int dragonAttack1 = attackMoveCEN.New_("Cometa draco", CardTypeEnum.Dragon, "Cometa draco causa da??o pero baja en 2 niveles el ataque del usuario");
                int dragonAttack2 = attackMoveCEN.New_("Cola drag??n", CardTypeEnum.Dragon, "Golpe con la cola que har?? caer a cualquier rival al que le aseste un golpe");
                int dragonAttack3 = attackMoveCEN.New_("Furia drag??n", CardTypeEnum.Dragon, "Furia drag??n resta 40 puntos de vida al objetivo siempre");
                int dragonAttack4 = attackMoveCEN.New_("Dragoaliento", CardTypeEnum.Dragon, "Dragoaliento causa da??o y tiene una probabilidad del 30% de paralizar al objetivo");
                int dragonAttack5 = attackMoveCEN.New_("Pulso drag??n", CardTypeEnum.Dragon, "Pulso drag??n causa da??o y no tiene ning??n efecto secundario");
                int dragonAttack6 = attackMoveCEN.New_("Danza drag??n", CardTypeEnum.Dragon, "Danza drag??n aumenta el ataque y la velocidad de la carta");

                //ELECTRIC ATTACKS
                int electricAttack1 = attackMoveCEN.New_("Calambrazo", CardTypeEnum.Electric, "Chispazo que electrocuta al rival");
                int electricAttack2 = attackMoveCEN.New_("Bola voltio", CardTypeEnum.Electric, "Bola voltio causa da??o y no tiene efecto secundario");
                int electricAttack3 = attackMoveCEN.New_("Campo El??ctrico", CardTypeEnum.Electric, "Campo el??ctrico es un movimiento de cambio de campo que electrifica el terreno de combate durante cinco turnos");
                int electricAttack4 = attackMoveCEN.New_("Chispa", CardTypeEnum.Electric, "Chispa causa da??o y tiene una probabilidad del 30% de paralizar al rival");
                int electricAttack5 = attackMoveCEN.New_("Inpactrueno", CardTypeEnum.Electric, "Trueno causa da??o y tiene una probabilidad del 10% de paralizar al objetivo");
                int electricAttack6 = attackMoveCEN.New_("Rayo", CardTypeEnum.Electric, "Lanza un rayo que tiene una probabilidad del 50% de paralizar al rival");

                //FIGHTING ATTACKS
                int fightingAttack1 = attackMoveCEN.New_("Pu??o fuerte", CardTypeEnum.Fighting, "Pu??etazo muy duro y con mucha intensidad");
                int fightingAttack2 = attackMoveCEN.New_("Patad??n", CardTypeEnum.Fighting, "Patada aer??a en el pecho");
                int fightingAttack3 = attackMoveCEN.New_("Pu??o din??mico", CardTypeEnum.Fighting, "Pu??o din??mico causa da??o y siempre confunde al objetivo");
                int fightingAttack4 = attackMoveCEN.New_("Pu??o drenaje", CardTypeEnum.Fighting, "Pu??o drenaje causa da??o y el usuario recupera el 50% del da??o realizado");
                int fightingAttack5 = attackMoveCEN.New_("Mascazo", CardTypeEnum.Fighting, "Torta con la mano abierta");
                int fightingAttack6 = attackMoveCEN.New_("Triple patada", CardTypeEnum.Fighting, "Triple patada causa da??o, golpeando al objetivo un m??ximo de 3 veces en un mismo turno");

                //FIRE ATTACKS
                int fireAttack1 = attackMoveCEN.New_("Ascuas", CardTypeEnum.Fire, "Ascuas causa da??o y tiene una probabilidad del 10% de quemar al objetivo");
                int fireAttack2 = attackMoveCEN.New_("Lanzallamas", CardTypeEnum.Fire, "Lanza una llamarada potente que quema al objetivo");
                int fireAttack3 = attackMoveCEN.New_("Pu??o fuego", CardTypeEnum.Fire, "Pu??o fuego causa da??o y tiene una probabilidad del 10% de quemar al objetivo");
                int fireAttack4 = attackMoveCEN.New_("Llama final", CardTypeEnum.Fire, "Llama final causa da??o y no tiene ning??n efecto secundario");
                int fireAttack5 = attackMoveCEN.New_("Infierno", CardTypeEnum.Fire, "Infierno causa da??o y siempre quema al objetivo.");
                int fireAttack6 = attackMoveCEN.New_("Colmillo ??gneo", CardTypeEnum.Fire, "Muerde al rival y lo quema");

                //FLYING ATTACKS
                int flyingAttack1 = attackMoveCEN.New_("Caida libre", CardTypeEnum.Flying, "Ca??da desde el cielo que aplastar?? a tus rivales");
                int flyingAttack2 = attackMoveCEN.New_("Ataque ala", CardTypeEnum.Flying, "Ataca con el ala y causa da??o al objetivo");
                int flyingAttack3 = attackMoveCEN.New_("Tornado", CardTypeEnum.Flying, "Invoca un tornado que causa da??o al objetivo y no tiene ning??n efecto secundario");
                int flyingAttack4 = attackMoveCEN.New_("Vuelo", CardTypeEnum.Flying, "Vuela alto para caer y asestar un golpe al objetivo");
                int flyingAttack5 = attackMoveCEN.New_("Golpe aereo", CardTypeEnum.Flying, "Golpe a??reo causa da??o y no tiene ning??n efecto secundario");
                int flyingAttack6 = attackMoveCEN.New_("Aire afilado", CardTypeEnum.Flying, "Aire afilado causa da??o y tiene una alta probabilidad de causar un golpe cr??tico");

                //GHOST ATTACKS
                int ghostAttack1 = attackMoveCEN.New_("Invisibilidad", CardTypeEnum.Ghost, "Desaparici??n visual para sorprender al rival ya que no sabe por donde le van a atacar");
                int ghostAttack2 = attackMoveCEN.New_("Bola sombra", CardTypeEnum.Ghost, "Lanza una bola de oscuridad que causa da??o al rival");
                int ghostAttack3 = attackMoveCEN.New_("Garra umbr??a", CardTypeEnum.Ghost, "Garra umbr??a causa da??o y tiene un alto ??ndice de causar un golpe cr??tico");
                int ghostAttack4 = attackMoveCEN.New_("Roba sombra", CardTypeEnum.Ghost, "Robasombra roba los cambios positivos en las estad??sticas del objetivo y, a continuaci??n causa da??o");
                int ghostAttack5 = attackMoveCEN.New_("Golpe fantasma", CardTypeEnum.Ghost, "El usuario desaparece en las tinieblas durante un turno y reaparece para asestar un golpe");
                int ghostAttack6 = attackMoveCEN.New_("Tinieblas", CardTypeEnum.Ghost, "Tinieblas resta una cantidad de vida equivalentes al nivel del rival");


                //GRASS ATTACKS
                int grassAttack1 = attackMoveCEN.New_("Megaagotar", CardTypeEnum.Grass, "Megaagotar causa da??o y el usuario recupera el 50% del da??o realizado al objetivo");
                int grassAttack2 = attackMoveCEN.New_("Hoja afilada", CardTypeEnum.Grass, "Lanza una hoja muy afilada con alta probabilidad de asestar un golpe cr??tico");
                int grassAttack3 = attackMoveCEN.New_("Hoja aguda", CardTypeEnum.Grass, "Hoja aguda causa da??o y tiene alta probabilidad de causar un golpe cr??tico");
                int grassAttack4 = attackMoveCEN.New_("Latigo cepa", CardTypeEnum.Grass, "Asesta un fuerto golpe con un latigo");
                int grassAttack5 = attackMoveCEN.New_("Planta feroz", CardTypeEnum.Grass, "Planta feroz causa da??o y no tiene ning??n efecto secundario");
                int grassAttack6 = attackMoveCEN.New_("Somnifero", CardTypeEnum.Grass, "Duerme al objetivo con un potente somnifero");

                //GROUND ATTACKS
                int groundAttack1 = attackMoveCEN.New_("Ataque arena", CardTypeEnum.Ground, "Ataque arena baja la precisi??n del objetivo");
                int groundAttack2 = attackMoveCEN.New_("Bucle arena", CardTypeEnum.Ground, "Bucle arena causa da??o y adem??s atrapa al rival");
                int groundAttack3 = attackMoveCEN.New_("Tierra viva", CardTypeEnum.Ground, "Tierra viva causa da??o y tiene una probabilidad del 10% de reducir la defensa del objetivo");
                int groundAttack4 = attackMoveCEN.New_("Terremoto", CardTypeEnum.Ground, "Crea un terremoto que da??a al objetivo");
                int groundAttack5 = attackMoveCEN.New_("Taladradora", CardTypeEnum.Ground, "Taladradora causa da??o y tiene una alta probabilidad de dar un golpe cr??tico");
                int groundAttack6 = attackMoveCEN.New_("Fisura", CardTypeEnum.Ground, "Asesta un golpe fulminante al rival");

                //ICE ATTACKS
                int iceAttack1 = attackMoveCEN.New_("Vaho g??lido", CardTypeEnum.Ice, "Congela al rival a trav??s del vaho que expulsa por la boca ya que sale muy fr??o");
                int iceAttack2 = attackMoveCEN.New_("Colmillo hielo", CardTypeEnum.Ice, "Muerde al rival y lo congela");
                int iceAttack3 = attackMoveCEN.New_("Bola hielo", CardTypeEnum.Ice, "Lanza una bola de hielo que causa da??o al rival");
                int iceAttack4 = attackMoveCEN.New_("Car??mbano", CardTypeEnum.Ice, "Car??mbano causa da??o, golpeando al objetivo de 2 a 5 veces en un mismo turno");
                int iceAttack5 = attackMoveCEN.New_("Rayo hielo", CardTypeEnum.Ice, "Lanza un rayo de hielo que tiene un 10% de probabilidades de congelar al rival");
                int iceAttack6 = attackMoveCEN.New_("Ventisca", CardTypeEnum.Ice, "Ventisca causa da??o y tiene una probabilidad del 10% de congelar al objetivo");

                //NORMAL ATTACKS
                int normalAttack1 = attackMoveCEN.New_("Placaje", CardTypeEnum.Normal, "Placaje con todo el cuerpo que puede llegar a tirar al rival");
                int normalAttack2 = attackMoveCEN.New_("Metr??nomo", CardTypeEnum.Normal, "Metr??nomo utiliza al azar casi cualquier otro ataque existente");
                int normalAttack3 = attackMoveCEN.New_("L??tigo", CardTypeEnum.Normal, "L??tigo baja la defensa del rival");
                int normalAttack4 = attackMoveCEN.New_("Explisi??n", CardTypeEnum.Normal, "Causa una gran explosi??n que hace da??o a ambos usuarios");
                int normalAttack5 = attackMoveCEN.New_("Golpe", CardTypeEnum.Normal, "Golpea entre 3 y 4 veces seguidas");
                int normalAttack6 = attackMoveCEN.New_("Bloqueo", CardTypeEnum.Normal, "Bloquea el siguiente ataque del rival");

                //POISON ATTACKS
                int poisonAttack1 = attackMoveCEN.New_("Puas t??xicas", CardTypeEnum.Poison, "Lanza una serie de puas que envenenan al rival");
                int poisonAttack2 = attackMoveCEN.New_("Gas Fat??dico", CardTypeEnum.Poison, "Gas putrefacto que ahogar?? a cualquier rival que lo inhale");
                int poisonAttack3 = attackMoveCEN.New_("Armadura ??cida", CardTypeEnum.Poison, "Se envuelve en una armadura que aumenta su defensa");
                int poisonAttack4 = attackMoveCEN.New_("Polvo veneno", CardTypeEnum.Poison, "Se envuelve en un polvo con posibilidad de envenenar al objetivo");
                int poisonAttack5 = attackMoveCEN.New_("Cola venenosa", CardTypeEnum.Poison, "Asesta un fuerte golpe con la cola que envenena");
                int poisonAttack6 = attackMoveCEN.New_("Colmillo veneno", CardTypeEnum.Poison, "Muerde al objetivo y lo envenena");

                //PSYCHIC ATTACKS
                int psychicAttack1 = attackMoveCEN.New_("Mareo", CardTypeEnum.Psychic, "Aturde al rival");
                int psychicAttack2 = attackMoveCEN.New_("Pesao", CardTypeEnum.Psychic, "Ser pesado es una cualidad que no muchos manejan");
                int psychicAttack3 = attackMoveCEN.New_("Ps??quico", CardTypeEnum.Psychic, "Ps??quico causa da??o y tiene una probabilidad del 30% de bajar el ataque del objetivo");
                int psychicAttack4 = attackMoveCEN.New_("Amnesia", CardTypeEnum.Psychic, "Aumentas tu ataque a costa de no recordar nada");
                int psychicAttack5 = attackMoveCEN.New_("Pantalla de luz", CardTypeEnum.Psychic, "Crea una pantalla de luz que refleja el ataque enemigo");
                int psychicAttack6 = attackMoveCEN.New_("Onda mental", CardTypeEnum.Psychic, "Onda mental causa da??o y no tiene ning??n efecto secundario");

                //ROCK ATTACKS
                int rockAttack1 = attackMoveCEN.New_("Pedrolo", CardTypeEnum.Rock, "Lanza una piedra muy grande que aplasta al rival");
                int rockAttack2 = attackMoveCEN.New_("Roca veloz", CardTypeEnum.Rock, "Lanza una roca a gran velocidad");
                int rockAttack3 = attackMoveCEN.New_("Rompe rocas", CardTypeEnum.Rock, "Romperrocas causa da??o y no tiene ning??n efecto secundario");
                int rockAttack4 = attackMoveCEN.New_("Roca afilada", CardTypeEnum.Rock, "Roca afilada causa da??o y tiene una alta probabilidad de dar un golpe cr??tico");
                int rockAttack5 = attackMoveCEN.New_("Tormenta de arena", CardTypeEnum.Rock, "Crea una tormenta de arena que da??a al rival");
                int rockAttack6 = attackMoveCEN.New_("Avalancha", CardTypeEnum.Rock, "Crea una avalancha que aplasta al rival");

                //WATER ATTACKS
                int waterAttack1 = attackMoveCEN.New_("Manguerazo", CardTypeEnum.Water, "Torrente de agua muy potente");
                int waterAttack2 = attackMoveCEN.New_("Hidroca??on", CardTypeEnum.Water, "Ca??on de agua a presi??n capaz de perforar al ace");
                int waterAttack3 = attackMoveCEN.New_("Pistola agua", CardTypeEnum.Water, "Disparo de agua de dudosa potencia");
                int waterAttack4 = attackMoveCEN.New_("Hidropulso", CardTypeEnum.Water, "Pulso de agua en todas las direcciones capaz de acertar m??s de una vez");
                int waterAttack5 = attackMoveCEN.New_("Acua jet", CardTypeEnum.Water, "Se envuelve en un torrente de agua y carga hacia el rival");
                int waterAttack6 = attackMoveCEN.New_("Concha filo", CardTypeEnum.Water, "El usuario usa una concha para cortar al usuario");



                //CARDS
                //BUG CARDS
                cardCEN.New_("Beedrill", "Tiene tres aguijones venenosos, dos en las patas anteriores y uno en la parte baja del abdomen, con los que ataca a sus enemigos una y otra vez", 200, "beedrill.jpg", CardTypeEnum.Bug, 0, 0, 0, 0, RarityEnum.Basic, new List<int> { bugAttack1, bugAttack2, bugAttack6, flyingAttack2, flyingAttack3 });
                cardCEN.New_("Beedrill Hacendado", "Como el beedrill normal pero de hacendado", 500, "beedrill_hacendado.jpg", CardTypeEnum.Bug, 0, 0, 0, 0, RarityEnum.Basic, new List<int> { bugAttack3, bugAttack5, bugAttack9, flyingAttack4, flyingAttack5 });
                cardCEN.New_("Mart??n El Bufas", "Mart??n Irles Rizo es E S P E C T A C U L A R", 1000000, "martin_el_bufas.png", CardTypeEnum.Bug, 46, 24, 18, 30, RarityEnum.Mythical, new List<int> { fightingAttack1, fightingAttack2, psychicAttack1 });

                //DRAGON CARDS
                cardCEN.New_("Haxorus", "Su mayor baza son sus colmillos, de gran tama??o y robustez. Lame la tierra en busca de minerales para mantenerlos fuertes y resistentes.", 700, "haxorus.jpg", CardTypeEnum.Dragon, 46, 24, 18, 30, RarityEnum.Mythical, new List<int> { dragonAttack1, dragonAttack3, dragonAttack5, rockAttack1 });

                //ELECTRIC CARDS
                cardCEN.New_("Pikachu", "Cuanto m??s potente es la energ??a el??ctrica que genera este Pok??mon, m??s suaves y el??sticas se vuelven las bolsas de sus mejillas", 2000, "pikachu.png", CardTypeEnum.Electric, 100, 90, 50, 70, RarityEnum.Basic, new List<int> { electricAttack1, electricAttack2, electricAttack3 });
                cardCEN.New_("Cable pelao", "Tremendo cable pelao ", 2000, "cable_pelao.png", CardTypeEnum.Electric, 100, 90, 50, 70, RarityEnum.Mythical, new List<int> { electricAttack1, electricAttack2, electricAttack3, electricAttack4, electricAttack5, electricAttack6 });

                //FIGHTING CARDS
                cardCEN.New_("Hitmonchan", "Sus pu??etazos cortan el aire. Son tan veloces que el m??nimo roce podr??a causar una quemadura", 2000, "hitmonchan.jpg", CardTypeEnum.Fighting, 100, 90, 50, 70, RarityEnum.Mythical, new List<int> { fightingAttack1, fightingAttack2, fightingAttack3 });


                //FIRE CARDS
                cardCEN.New_("Charizard", "Escupe un fuego tan caliente que funde las rocas. Causa incendios forestales sin querer", 2000, "charizard.jpg", CardTypeEnum.Fire, 100, 90, 50, 70, RarityEnum.Basic, new List<int> { fireAttack1, fireAttack2, fireAttack3, flyingAttack1, flyingAttack2 });


                //FLYING CARDS
                cardCEN.New_("Pidgeot", "Este Pok??mon vuela a una velocidad de 2 mach en busca de presas. Sus grandes garras son armas muy peligrosas", 4700, "pidgeot.jpg", CardTypeEnum.Flying, 66, 12, 90, 23, RarityEnum.Basic, new List<int> { flyingAttack1, flyingAttack2, flyingAttack4, });
                cardCEN.New_("Mosca mutante", "Mitad mosca, mitad hombre. Se dice que est?? mutando como el de la mosca", 2500, "mosca_mutante.png", CardTypeEnum.Flying, 39, 21, 18, 36, RarityEnum.Uncommon, new List<int> { flyingAttack1, flyingAttack3, flyingAttack6, poisonAttack1 });
                cardCEN.New_("Perro motocicl??n", "Che par??, emosio, ni prend?? la moto, es el perro motocicl??n", 4700, "perro_motociclon.png", CardTypeEnum.Flying, 66, 12, 90, 23, RarityEnum.Rare, new List<int> { flyingAttack1, flyingAttack3, flyingAttack5, groundAttack1, groundAttack2 });

                //GHOST CARDS
                cardCEN.New_("Gengar", "Las noches de luna llena, a este Pok??mon le gusta imitar las sombras de la gente y burlarse de sus miedos", 2000, "gengar.jpg", CardTypeEnum.Ghost, 100, 90, 50, 70, RarityEnum.Basic, new List<int> { ghostAttack1, ghostAttack3, ghostAttack4, poisonAttack3 });

                //GRASS CARDS
                cardCEN.New_("Torterra", "Las gentes de anta??o cre??an que el planeta se sustentaba en la espalda de un gran Torterra", 4700, "torterra.jpg", CardTypeEnum.Grass, 55, 60, 18, 48, RarityEnum.Legendary, new List<int> { grassAttack1, grassAttack2, groundAttack1, groundAttack2 });
                cardCEN.New_("El Diego", "Una especie de Dios argentino. Se le da bien eso del f??tbol", 4700, "el_diego.png", CardTypeEnum.Grass, 55, 60, 18, 48, RarityEnum.Legendary, new List<int> { grassAttack3, grassAttack4, grassAttack5, normalAttack1 });

                //GROUND CARDS
                cardCEN.New_("Groudon", "A Groudon siempre se le ha descrito como el Pok??mon que expandi?? los continentes", 8000, "groudon.jpg", CardTypeEnum.Ground, 30, 60, 40, 10, RarityEnum.Legendary, new List<int> { groundAttack1, groundAttack2, groundAttack6, fireAttack1 });
                cardCEN.New_("Ford Fiesta", "Se vende ford fiesta diesel 1.4 Tdci 70 Cv my Nuevo lleva climatizador bizona cierre centralizado con mando elevalluna electricos", 8000, "ford_fiesta.png", CardTypeEnum.Ground, 30, 60, 40, 10, RarityEnum.Legendary, new List<int> { groundAttack1, groundAttack2, groundAttack6, fireAttack1 });


                //ICE CARDS
                cardCEN.New_("Articuno", "Se dice que sus bellas alas azules se componen de hielo. Vuela en torno a las monta??as nevadas con su larga cola al viento", 400, "articuno.jpg", CardTypeEnum.Ice, 10, 20, 10, 10, RarityEnum.Basic, new List<int> { iceAttack1, iceAttack2, iceAttack4, iceAttack5 });
                cardCEN.New_("Papa Noel", "Regalos para todos", 400, "papa_noel.png", CardTypeEnum.Ice, 10, 20, 10, 10, RarityEnum.Uncommon, new List<int> { normalAttack1, iceAttack1, iceAttack2, iceAttack3 });

                //NORMAL CARDS
                cardCEN.New_("Perro panson", "Todo chiquito, todo panson", 1000, "perro_panzon.png", CardTypeEnum.Normal, 30, 10, 25, 10, RarityEnum.Basic, new List<int> { normalAttack1, normalAttack3, fightingAttack1 });
                cardCEN.New_("Mortadelo", "Personaje c??mico que te sucumbe con su labia y sus bromas", 3200, "mortadelo.png", CardTypeEnum.Normal, 46, 24, 18, 30, RarityEnum.Rare, new List<int> { normalAttack1, normalAttack2, normalAttack3, fightingAttack2 });
                cardCEN.New_("Snorlax", "No se encuentra satisfecho hasta haber ingerido 400 kg de comida cada d??a. Cuando acaba de comer, se queda dormido", 3200, "snorlax.png", CardTypeEnum.Normal, 46, 24, 18, 30, RarityEnum.Rare, new List<int> { normalAttack1, normalAttack5, normalAttack6 });


                //POISON CARDS
                cardCEN.New_("Weezing", "Usa sus dos cuerpos para mezclar gases.", 3200, "weezing.jpg", CardTypeEnum.Poison, 46, 24, 18, 30, RarityEnum.Rare, new List<int> { poisonAttack1, poisonAttack2, poisonAttack4 });
                cardCEN.New_("Pepe", "Uno de los cl??sicos.", 3200, "pepe.jpg", CardTypeEnum.Poison, 46, 24, 18, 30, RarityEnum.Rare, new List<int> { poisonAttack2, poisonAttack3, waterAttack3, normalAttack1 });


                //PSYCHIC CARDS
                cardCEN.New_("Mewtwo", "Su ADN es casi el mismo que el de Mew. Sin embargo, su tama??o y car??cter son muy diferentes", 3200, "mewtwo.png", CardTypeEnum.Psychic, 46, 24, 18, 30, RarityEnum.Common, new List<int> { psychicAttack1, psychicAttack3, psychicAttack5 });
                cardCEN.New_("Baby Yoda", "M??s peque??o que un ??tomo. Cuidado que se enfada", 8000, "baby_yoda.png", CardTypeEnum.Psychic, 30, 60, 40, 10, RarityEnum.Common, new List<int> { psychicAttack2, psychicAttack4, psychicAttack6 });
                cardCEN.New_("Pepe gal??ctico", "Pepe gal??ctico", 3200, "pepe_galactico.png", CardTypeEnum.Psychic, 46, 24, 18, 30, RarityEnum.Legendary, new List<int> { psychicAttack1, psychicAttack2, psychicAttack3, psychicAttack6, poisonAttack2 });


                //ROCK CARDS
                cardCEN.New_("Onix", "Al abrirse paso bajo tierra, va absorbiendo todo lo que encuentra. Eso hace que su cuerpo sea as?? de s??lido", 3200, "onix.jpg", CardTypeEnum.Rock, 46, 24, 18, 30, RarityEnum.Rare, new List<int> { rockAttack1, rockAttack2, groundAttack3 });

                //WATER CARDS
                cardCEN.New_("Mart??n Waterpolista", "", 3200, "martin_waterpolista.png", CardTypeEnum.Water, 46, 24, 18, 30, RarityEnum.Legendary, new List<int> { waterAttack1, waterAttack3, waterAttack5, waterAttack6, fightingAttack3, fightingAttack5 });
                cardCEN.New_("Feraligatr", "Al morder con sus feroces fauces, mueve su cabeza despedazando salvajemente a su v??ctima", 3200, "feraligatr.jpg", CardTypeEnum.Water, 46, 24, 18, 30, RarityEnum.Common, new List<int> { waterAttack2, waterAttack3, waterAttack4 });

                cardCEN.New_("Lebron James", "Esto no es un juego", 1200, "lebron.png", CardTypeEnum.Fighting, 25, 40, 36, 10, RarityEnum.Basic, new List<int> { groundAttack1, grassAttack1, bugAttack1 });
                cardCEN.New_("??", "??", 1500, "a.png", CardTypeEnum.Psychic, 25, 40, 36, 10, RarityEnum.Basic, new List<int> { groundAttack1, grassAttack1, bugAttack1 });
                cardCEN.New_("Tramboliko", "Hay que saber subir y bajar", 2000, "tramboliko.jpg", CardTypeEnum.Psychic, 25, 40, 36, 10, RarityEnum.Basic, new List<int> { groundAttack1, grassAttack1, bugAttack1 });



                //BASE PACKS
                PackCEN packCEN = new PackCEN ();

                packCEN.New_ ("Sobre B??sico Peque??o", "Sobre que contiene entre 1 y 5 cartas b??sicas", 100, "", RarityEnum.Basic, 1, 5, CardTypeEnum.All, RarityEnum.Basic);
                packCEN.New_ ("Sobre B??sico Mediano", "Sobre que contiene entre 5 y 10 cartas b??sicas", 300, "", RarityEnum.Basic, 5, 10, CardTypeEnum.All, RarityEnum.Basic);
                packCEN.New_ ("Sobre B??sico Grande", "Sobre que contiene entre 10 y 15 cartas b??sicas", 500, "", RarityEnum.Basic, 10, 15, CardTypeEnum.All, RarityEnum.Basic);

                packCEN.New_ ("Sobre Com??n Peque??o", "Sobre que contiene entre 1 y 5 cartas b??sicas y comunes", 150, "", RarityEnum.Common, 1, 5, CardTypeEnum.All, RarityEnum.Basic | RarityEnum.Common);
                packCEN.New_ ("Sobre Com??n Mediano", "Sobre que contiene entre 5 y 10 cartas b??sicas y comunes", 350, "", RarityEnum.Common, 5, 10, CardTypeEnum.All, RarityEnum.Basic | RarityEnum.Common);
                packCEN.New_ ("Sobre Com??n Grande", "Sobre que contiene entre 10 y 15 cartas b??sicas y comunes", 550, "", RarityEnum.Common, 10, 15, CardTypeEnum.All, RarityEnum.Basic | RarityEnum.Common);

                packCEN.New_ ("Sobre Poco Com??n Peque??o", "Sobre que contiene entre 1 y 5 cartas b??sicas, comunes y poco comunes", 200, "", RarityEnum.Uncommon, 1, 5, CardTypeEnum.All, RarityEnum.Basic | RarityEnum.Common | RarityEnum.Uncommon);
                packCEN.New_ ("Sobre Poco Com??n Mediano", "Sobre que contiene entre 5 y 10 cartas b??sicas, comunes y poco comunes", 400, "", RarityEnum.Uncommon, 5, 10, CardTypeEnum.All, RarityEnum.Basic | RarityEnum.Common | RarityEnum.Uncommon);
                packCEN.New_ ("Sobre Poco Com??n Grande", "Sobre que contiene entre 10 y 15 cartas b??sicas, comunes y poco comunes", 600, "", RarityEnum.Uncommon, 10, 15, CardTypeEnum.All, RarityEnum.Basic | RarityEnum.Common | RarityEnum.Uncommon);

                packCEN.New_ ("Sobre Raro Peque??o", "Sobre que contiene entre 1 y 5 cartas b??sicas, comunes, poco comunes y raras", 250, "", RarityEnum.Rare, 1, 5, CardTypeEnum.All, RarityEnum.Basic | RarityEnum.Common | RarityEnum.Uncommon | RarityEnum.Rare);
                packCEN.New_ ("Sobre Raro Mediano", "Sobre que contiene entre 5 y 10 cartas b??sicas, comunes, poco comunes y raras", 450, "", RarityEnum.Rare, 5, 10, CardTypeEnum.All, RarityEnum.Basic | RarityEnum.Common | RarityEnum.Uncommon | RarityEnum.Rare);
                packCEN.New_ ("Sobre Raro Grande", "Sobre que contiene entre 10 y 15 cartas b??sicas, comunes, poco comunes y raras", 650, "", RarityEnum.Rare, 10, 15, CardTypeEnum.All, RarityEnum.Basic | RarityEnum.Common | RarityEnum.Uncommon | RarityEnum.Rare);

                packCEN.New_ ("Sobre ??pico Peque??o", "Sobre que contiene entre 1 y 5 cartas comunes, poco comunes, raras y ??picas", 300, "", RarityEnum.Epic, 1, 5, CardTypeEnum.All, RarityEnum.Common | RarityEnum.Uncommon | RarityEnum.Rare | RarityEnum.Epic);
                packCEN.New_ ("Sobre ??pico Mediano", "Sobre que contiene entre 5 y 10 cartas comunes, poco comunes, raras y ??picas", 500, "", RarityEnum.Epic, 5, 10, CardTypeEnum.All, RarityEnum.Common | RarityEnum.Uncommon | RarityEnum.Rare | RarityEnum.Epic);
                packCEN.New_ ("Sobre ??pico Grande", "Sobre que contiene entre 10 y 15 cartas comunes, poco comunes, raras y ??picas", 700, "", RarityEnum.Epic, 10, 15, CardTypeEnum.All, RarityEnum.Common | RarityEnum.Uncommon | RarityEnum.Rare | RarityEnum.Epic);

                packCEN.New_ ("Sobre Legendario Peque??o", "Sobre que contiene entre 1 y 5 cartas poco comunes, raras, ??picas y legendarias", 350, "", RarityEnum.Legendary, 1, 5, CardTypeEnum.All, RarityEnum.Uncommon | RarityEnum.Rare | RarityEnum.Epic | RarityEnum.Legendary);
                packCEN.New_ ("Sobre Legendario Mediano", "Sobre que contiene entre 5 y 10 cartas poco comunes, raras, ??picas y legendarias", 550, "", RarityEnum.Legendary, 5, 10, CardTypeEnum.All, RarityEnum.Uncommon | RarityEnum.Rare | RarityEnum.Epic | RarityEnum.Legendary);
                packCEN.New_ ("Sobre Legendario Grande", "Sobre que contiene entre 10 y 15 cartas poco comunes, raras, ??picas y legendarias", 750, "", RarityEnum.Legendary, 10, 15, CardTypeEnum.All, RarityEnum.Uncommon | RarityEnum.Rare | RarityEnum.Epic | RarityEnum.Legendary);

                packCEN.New_ ("Sobre M??tico Peque??o", "Sobre que contiene entre 1 y 5 cartas raras, ??picas, legendarias y m??ticas", 400, "", RarityEnum.Mythical, 1, 5, CardTypeEnum.All, RarityEnum.Rare | RarityEnum.Epic | RarityEnum.Legendary | RarityEnum.Mythical);
                packCEN.New_ ("Sobre M??tico Mediano", "Sobre que contiene entre 5 y 10 cartas raras, ??picas, legendarias y m??ticas", 600, "", RarityEnum.Mythical, 5, 10, CardTypeEnum.All, RarityEnum.Rare | RarityEnum.Epic | RarityEnum.Legendary | RarityEnum.Mythical);
                packCEN.New_ ("Sobre M??tico Grande", "Sobre que contiene entre 10 y 15 cartas raras, ??picas, legendarias y m??ticas", 800, "", RarityEnum.Mythical, 10, 15, CardTypeEnum.All, RarityEnum.Rare | RarityEnum.Epic | RarityEnum.Legendary | RarityEnum.Mythical);

                packCEN.New_("Sobre tipo bicho", "Sobre que contiene entre 1 y 10 cartas de tipo bicho", 800, "", RarityEnum.Uncommon, 1, 10, CardTypeEnum.Bug, RarityEnum.All);
                packCEN.New_("Sobre tipo dragon", "Sobre que contiene entre 1 y 10 cartas de tipo dragon", 800, "", RarityEnum.Uncommon, 1, 10, CardTypeEnum.Dragon, RarityEnum.All);
                packCEN.New_("Sobre tipo el??ctrico", "Sobre que contiene entre 1 y 10 cartas de tipo el??ctrico", 800, "", RarityEnum.Uncommon, 1, 10, CardTypeEnum.Electric, RarityEnum.All);
                packCEN.New_("Sobre tipo lucha", "Sobre que contiene entre 1 y 10 cartas de tipo lucha", 800, "", RarityEnum.Uncommon, 1, 10, CardTypeEnum.Fighting, RarityEnum.All);
                packCEN.New_("Sobre tipo fuego", "Sobre que contiene entre 1 y 10 cartas de tipo fuego", 800, "", RarityEnum.Uncommon, 1, 10, CardTypeEnum.Fire, RarityEnum.All);
                packCEN.New_("Sobre tipo volador", "Sobre que contiene entre 1 y 10 cartas de tipo volador", 800, "", RarityEnum.Uncommon, 1, 10, CardTypeEnum.Flying, RarityEnum.All);
                packCEN.New_("Sobre tipo fantasma", "Sobre que contiene entre 1 y 10 cartas de tipo fantasma", 800, "", RarityEnum.Uncommon, 1, 10, CardTypeEnum.Ghost, RarityEnum.All);
                packCEN.New_("Sobre tipo planta", "Sobre que contiene entre 1 y 10 cartas de tipo planta", 800, "", RarityEnum.Uncommon, 1, 10, CardTypeEnum.Grass, RarityEnum.All);
                packCEN.New_("Sobre tipo tierra", "Sobre que contiene entre 1 y 10 cartas de tipo tierra", 800, "", RarityEnum.Uncommon, 1, 10, CardTypeEnum.Ground, RarityEnum.All);
                packCEN.New_("Sobre tipo hielo", "Sobre que contiene entre 1 y 10 cartas de tipo hielo", 800, "", RarityEnum.Uncommon, 1, 10, CardTypeEnum.Ice, RarityEnum.All);
                packCEN.New_("Sobre tipo normal", "Sobre que contiene entre 1 y 10 cartas de tipo normal", 800, "", RarityEnum.Uncommon, 1, 10, CardTypeEnum.Normal, RarityEnum.All);
                packCEN.New_("Sobre tipo veneno", "Sobre que contiene entre 1 y 10 cartas de tipo veneno", 800, "", RarityEnum.Uncommon, 1, 10, CardTypeEnum.Poison, RarityEnum.All);
                packCEN.New_("Sobre tipo ps??quico", "Sobre que contiene entre 1 y 10 cartas de tipo ps??quico", 800, "", RarityEnum.Uncommon, 1, 10, CardTypeEnum.Psychic, RarityEnum.All);
                packCEN.New_("Sobre tipo roca", "Sobre que contiene entre 1 y 10 cartas de tipo roca", 800, "", RarityEnum.Uncommon, 1, 10, CardTypeEnum.Rock, RarityEnum.All);
                packCEN.New_("Sobre tipo agua", "Sobre que contiene entre 1 y 10 cartas de tipo agua", 800, "", RarityEnum.Uncommon, 1, 10, CardTypeEnum.Water, RarityEnum.All);


                //VIRTUALUSERS y USER CARD
                VirtualUserCEN virtualUserCEN = new VirtualUserCEN ();
                int virtualUser1 = virtualUserCEN.New_ ("Pass", "Usuario 1", "email@gmail.com");
                int virtualUser2 = virtualUserCEN.New_ ("Pass", "Usuario 2", "email1@gmail.com");
                int virtualUser3 = virtualUserCEN.New_ ("virtualUser12345", "Pepito123", "Pepito123@email.com");
                int virtualUser4 = virtualUserCEN.New_ ("virtualUser12345", "Juan123", "Juan123@email.com");

                //TOKEN PACKS
                TokenPackCEN tokenPackCEN = new TokenPackCEN ();

                tokenPackCEN.New_ ("Pack B??sico Peque??o", 1.0, 100);
                tokenPackCEN.New_ ("Pack Top Peque??o", 2.5, 240);
                tokenPackCEN.New_ ("Pack B??sico Mediano", 5.0, 700);
                tokenPackCEN.New_ ("Pack Top Mediano", 10.0, 1450);
                tokenPackCEN.New_ ("Pack B??sico Grande", 25.0, 3700);
                tokenPackCEN.New_ ("Pack Top Grande", 50.0, 7450);
                tokenPackCEN.New_ ("Pack B??sico Gigante", 100.0, 14950);
                tokenPackCEN.New_ ("Pack Top Gigante", 200.0, 29950);

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
