using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLExternal.Level
{
    /// <summary>
    ///     Класс моделей уровней
    /// </summary>
    public static class LevelModel
    {
        /// <summary>
        ///     Расстановка платформ на уровнях
        /// </summary>
        public static string[] Platforms { get; } =
        {
            "2G GH", // 1
            "1A BL NX",
            "3K FH",
            "AC F2 WV",
            "DS G2 PU", // 5
            "2G GV VX",
            "BA HR 3L",
            "2G GQ QT",
            "3L 3M VX",
            "AC MW K3", // 10
            "4P AK",
            "1A GV",
            "2G GV VW",
            "4P PS",
            "2G DN SX JY", // 15
            "CA 3K UX",
            "4P PR GH",
            "3L HR DS SX",
            "2G GJ UV",
            "2H HM NX OY", // 20
            "3L LG GJ",
            "1C CE NO RW",
            "3K KM IS",
            "1B UV ET",
            "2F UX XY", // 25
            "2F KU IX",
            "4Q QR KM",
            "5U VX FH DS",
            "2F LV GJ MW",
            "2G GJ DE KU", // 30
            "2G QT HJ DE",
            "3K AC VW IS",
            "3L LQ EO",
            "1A AP HM",
            "3K UV OV", // 35
            "4R RM AK UV",
            "4P UX DN",
            "2G UV CM DE QT",
            "3M PQ FG CM MW",
            "2F AC UW QT" // 40
        };

        /// <summary>
        ///     Игровые уровни
        /// </summary>
        public static string[] Levels { get; } =
        {
            "9 S H R G 2", // 1
            "1 A B L M N X Y Z",
            "3 F K C H R T W 9",
            "2 A F C D N L V W T Y 9",
            "2 G Q A P U S T D 9", // 5
            "2 G C R X V A K N 9",
            "3 A B L N C E H R 8",
            "2 G Q W X I D T 9",
            "3 L V X A C M R J T 7",
            "3 A C M E J O W F K 8", // 10
            "4 K P N A C D H R W 8",
            "1 A B E T S G V P U 9",
            "2 G V C R W D K U O 9",
            "4 P D S E O L V H W T 7",
            "2 G J Y S X Q D N 9", // 15
            "3 F K U I X A C 8",
            "4 P R D N E J H W 8",
            "3 D S H R B L V X O 8",
            "2 J Y V A K U C G Q R N S 9",
            "2 K M N X O Y H R U 9", // 20
            "3 D C A J T S Y W G L V M P 8",
            "1 2 R W G L K U C H N O E Z",
            "3 A B D I K M O U V S X 8",
            "1 D B H F K U Q V N X E T Y 7",
            "2 F K P U L Q C R I X Y O 9", // 25
            "2 K B L D I X Q F U M W O T 9",
            "4 F K M R I S J G Q O 9",
            "5 J H F B D S X L V O P U 8",
            "2 F G L C M E J W Y V A S P 9",
            "2 G V C E D J A K U R N X 9", // 30
            "2 G H W B E D J Q T A K U N 9",
            "3 G Q I S V A K O Y U F C D I 8",
            "3 B L W D E Q I S F O Y P U H I 8",
            "1 D C G S X A P U E J H Y 8",
            "3 C H M L S A K O N J U V Y 9", // 35
            "4 X H M R V D G S A K U O Y 7",
            "4 B G H A D N E Q T Y X P U 7",
            "2 G D C M N E Q V T P X 8",
            "3 G F C M W N J Q P Y A 8",
            "2 E C M I W Q T Y X A F K U 7" // 40

        };

        /// <summary>
        ///     Решения игровых уровней 
        /// </summary>
        public static string[] Solutions { get; } =
        {
            "2GHRS9", // 1
            "1ABLMNXYZ",
            "3KFHRT9",
            "2FACDNLVWYT9",
            "2GQSDAPQST9", // 5
            "2G-NX GV-KN VX-AK NX-AC KN-CR CR-R9",
            "3L-BL AB-BC BC-CH HR-CE CH-BC BL-LN LN-N8",
            "2G-GI QT-IX WX-DI IX-QT DI-T9",
            "3L-LV VX-CM LV-AC LM-MR AC-RT CM-JT MR-J7",
            "3K-FK FK-AF AC-CM MW-AC CM-CE AF-EJ EJ-JO JO-O8", //10
            "4P-KP AK-PR KP-RW PR-HR RW-CH HR-AC CH-CD AC-DN DN-N8",
            "1A-AB AB-BG GV-BE BG-AB BE-AP AB-PU AP-PS PU-ST ST-T9",
            "VW-UV 2G-KU GV-KN UV-NO KU-DN NO-CD KN-CR CR-R9",
            "4P-ST PS-DS ST-DE DS-LO DE-OT EO-LV OT-VW LO-HW HW-H7",
            "2G-GQ GQ-QS SX-NS DN-GQ NS-SX SX-XY JY-GJ QS-S9", //15
            "3K-FK FK-AF AC-CM CM-KM KM-KU UX-IX IX-FI AF-FK KU-KM FI-M8",
            "4P-RW PR-HR HR-HJ GH-EJ HJ-HR RW-GH HR-HJ GH-DE HJ-DN DN-N8",
            "3L-LV LV-VX SX-RS HR-BD RS-SX BD-LV DS-LO SX-O8",
            "2G-GQ GJ-JY JY-VY UV-QV VY-GJ QV-QR GJ-CR GQ-AC QR-RS AC-S9",
            "HM-MN NX-KM MN-NO OY-NX NO-MN NX-KU MN-HM 2H-UX HM-MR UX-R9", // 20
            "3L-JT GL-ST GJ-DS ST-TY JT-WY TY-VW WY-MW VW-LM MW-CM LM-CD DS-M8",
            "CE-EO EO-LN NO-KL LN-KU KU-UW UW-HR RW-GH GH-GL KL-GH GL-CH GH-RW IC-WZ",
            "KM-AK 3K-AB AK-BD AB-DI DI-SX IS-VX SX-UV VX-KU UV-3K KU-AK 3K-AB BD-KM AB-3K AK-MO 3K-O8",
            "1B-BD BD-DN DN-NX NX-VX UV-XY XY-TY ET-QT TY-QV QT-BQ VX-BD QV-DE BQ-ET BD-DN ET-KN DE-FK DN-FH KN-H7",
            "2F-FK FK-KP KP-PU XY-KP PU-FK KP-PU UX-IX IX-FI FK-KP PU-KL KP-FK FI-LO FK-LQ KL-QR LO-R9", // 25
            "2F-FK FK-KL KU-BL KL-LM BL-MW LM-WX WX-DI IX-FI DI-FK FK-KL KL-LM MW-MO LM-OT OT-T9",
            "QR-MR KM-MO MR-QR 4Q-GQ QR-FG GQ-GI FG-IJ IJ-JO JO-MR MO-KM MR-FK FK-FG GI-IS IS-S9",
            "5U-UV UV-SX DS-PS VX-FP FH-VX PS-DS VX-BD DS-PS FP-VX PS-DS BD-LV DS-LO SX-O8",
            "2F-FG FG-GL GL-LM LV-WY LM-GL GL-EJ GJ-JY MW-CE WY-AC JY-GJ EJ-AF AC-FP AF-FG GJ-PS FP-S9",
            "GJ-GV 2G-VX VX-NX NX-DN DE-CD DN-AC AC-AK KU-AC AK-DN AC-NX DN-VX GV-KN NX-DN KN-CR CR-R9", // 30
            "2G-GQ GQ-JT QT-HW JT-UW HJ-KU HW-KN KU-DN DN-BD DE-BG BD-2G BG-GH 2G-HJ GH-EJ HJ-JT EJ-T9",
            "3K-FK FK-AF AF-CD CD-DI IS-GI DI-FG GI-GQ FG-QV VW-FG QV-AF AC-QS AF-QV FG-VW GQ-WY QS-OY VW-O8",
            "3L-QS LQ-PQ QS-FP PQ-PU FP-UW UW-WY WY-OY EO-WY OY-UW WY-FP UW-FH PU-HI FH-IS HI-DI IS-BD DI-DE BD-EO DE-O8",
            "1A-PU AP-PS PU-SX PS-DS SX-CD CD-CH HM-CD CH-SX DS-PS SX-PU PS-DS CD-SX DS-PS SX-UV PS-GV PU-GH UV-HM GV-M8",
            "3K-KL KL-LM LM-MN MN-NO NO-JO OY-HJ JO-CH HJ-AC AC-AK AK-KU KU-LV UV-LM LM-HM CH-LM LV-HJ LM-JO HM-NO HJ-OY JO-NS OY-S9", // 35
            "MR-RS 4R-DS RS-SX DS-AD AK-KU KU-VX UV-XY VX-OY OY-MO MO-KM KM-AK AD-DS XY-RS SX-MR DS-4R RS-HM 4R-H7",
            "4P-PU UX-AP PU-PQ AP-QT PQ-TY QT-ET TY-DE DN-BD DE-TY ET-QT TY-PQ QT-AP PQ-AB AB-BG BD-GQ BG-PQ AP-QT PQ-GH QT-H7",
            "2G-GQ QT-ET DE-CD CD-MN CM-NX NX-VX UV-QV GQ-NX NX-CM MN-CD CD-DE ET-QT QV-UV VX-PU PU-PM CM-PU UV-MN PM-N8",
            "CM-WY 3M-JY WY-CM MW-AC CM-MW MW-WY JY-GJ FG-AF AC-FP PQ-FG FP-AC GJ-JY WY-MW MW-CM AF-MN AC-MW CM-WY JY-3M WY-N8",
            "2F-AF AC-CM CM-KM KM-KU UW-KM KU-CM CM-AC AF-FK KM-CM AC-KM CM-KU KM-UW FK-WX WX-XY XY-TY QT-ET TY-XY XY-WX WX-FK UW-KM KU-CM KM-AC CM-KM FK-AF AC-CM KM-CE CM-AC ET-FI AC-I7", // 40
        };

        /*/// <summary>
        ///     Решения игровых уровней 
        /// </summary>
        public static string[] Solutions { get; } =
        {
            "2G-HR GH-RS HR-S9", // 1
            "1A-AB AB-LM LM-MN MN-XY XY-YZ",
            "3K-FK FK-CH FH-HR CH-RW HR-RT RW-T9",
            "2F-AF AF-CD AC-DN DN-LN LN-LV LV-WY VW-TY TY-T9",
            "2G-GQ GQ-QS DS-AD AD-AP PU-PQ PQ-ST ST-T9", // 5
            "2G-NX GV-KN VX-AK NX-AC KN-CR CR-R9",
            "3L-BL AB-BC BC-CH HR-CE CH-BC BL-LN LN-N8",
            "2G-GI QT-IX WX-DI IX-QT DI-T9",
            "3L-LV VX-CM LV-AC LM-MR AC-RT CM-JT MR-J7",
            "3K-FK FK-AF AC-CM MW-AC CM-CE AF-EJ EJ-JO JO-O8", //10
            "4P-KP AK-PR KP-RW PR-HR RW-CH HR-AC CH-CD AC-DN DN-N8",
            "1A-AB AB-BG GV-BE BG-AB BE-AP AB-PU AP-PS PU-ST ST-T9",
            "VW-UV 2G-KU GV-KN UV-NO KU-DN NO-CD KN-CR CR-R9",
            "4P-ST PS-DS ST-DE DS-LO DE-OT EO-LV OT-VW LO-HW HW-H7",
            "2G-GQ GQ-QS SX-NS DN-GQ NS-SX SX-XY JY-GJ QS-S9", //15
            "3K-FK FK-AF AC-CM CM-KM KM-KU UX-IX IX-FI AF-FK KU-KM FI-M8",
            "4P-RW PR-HR HR-HJ GH-EJ HJ-HR RW-GH HR-HJ GH-DE HJ-DN DN-N8",
            "3L-LV LV-VX SX-RS HR-BD RS-SX BD-LV DS-LO SX-O8",
            "2G-GQ GJ-JY JY-VY UV-QV VY-GJ QV-QR GJ-CR GQ-AC QR-RS AC-S9",
            "HM-MN NX-KM MN-NO OY-NX NO-MN NX-KU MN-HM 2H-UX HM-MR UX-R9", // 20
            "3L-JT GL-ST GJ-DS ST-TY JT-WY TY-VW WY-MW VW-LM MW-CM LM-CD DS-M8",
            "CE-EO EO-LN NO-KL LN-KU KU-UW UW-HR RW-GH GH-GL KL-GH GL-CH GH-RW IC-WZ",
            "KM-AK 3K-AB AK-BD AB-DI DI-SX IS-VX SX-UV VX-KU UV-3K KU-AK 3K-AB BD-KM AB-3K AK-MO 3K-O8",
            "1B-BD BD-DN DN-NX NX-VX UV-XY XY-TY ET-QT TY-QV QT-BQ VX-BD QV-DE BQ-ET BD-DN ET-KN DE-FK DN-FH KN-H7",
            "2F-FK FK-KP KP-PU XY-KP PU-FK KP-PU UX-IX IX-FI FK-KP PU-KL KP-FK FI-LO FK-LQ KL-QR LO-R9", // 25
            "2F-FK FK-KL KU-BL KL-LM BL-MW LM-WX WX-DI IX-FI DI-FK FK-KL KL-LM MW-MO LM-OT OT-T9",
            "QR-MR KM-MO MR-QR 4Q-GQ QR-FG GQ-GI FG-IJ IJ-JO JO-MR MO-KM MR-FK FK-FG GI-IS IS-S9",
            "5U-UV UV-SX DS-PS VX-FP FH-VX PS-DS VX-BD DS-PS FP-VX PS-DS BD-LV DS-LO SX-O8",
            "2F-FG FG-GL GL-LM LV-WY LM-GL GL-EJ GJ-JY MW-CE WY-AC JY-GJ EJ-AF AC-FP AF-FG GJ-PS FP-S9",
            "GJ-GV 2G-VX VX-NX NX-DN DE-CD DN-AC AC-AK KU-AC AK-DN AC-NX DN-VX GV-KN NX-DN KN-CR CR-R9", // 30
            "2G-GQ GQ-JT QT-HW JT-UW HJ-KU HW-KN KU-DN DN-BD DE-BG BD-2G BG-GH 2G-HJ GH-EJ HJ-JT EJ-T9",
            "3K-FK FK-AF AF-CD CD-DI IS-GI DI-FG GI-GQ FG-QV VW-FG QV-AF AC-QS AF-QV FG-VW GQ-WY QS-OY VW-O8",
            "3L-QS LQ-PQ QS-FP PQ-PU FP-UW UW-WY WY-OY EO-WY OY-UW WY-FP UW-FH PU-HI FH-IS HI-DI IS-BD DI-DE BD-EO DE-O8", 
            "1A-PU AP-PS PU-SX PS-DS SX-CD CD-CH HM-CD CH-SX DS-PS SX-PU PS-DS CD-SX DS-PS SX-UV PS-GV PU-GH UV-HM GV-M8",
            "3K-KL KL-LM LM-MN MN-NO NO-JO OY-HJ JO-CH HJ-AC AC-AK AK-KU KU-LV UV-LM LM-HM CH-LM LV-HJ LM-JO HM-NO HJ-OY JO-NS OY-S9", // 35
            "MR-RS 4R-DS RS-SX DS-AD AK-KU KU-VX UV-XY VX-OY OY-MO MO-KM KM-AK AD-DS XY-RS SX-MR DS-4R RS-HM 4R-H7",
            "4P-PU UX-AP PU-PQ AP-QT PQ-TY QT-ET TY-DE DN-BD DE-TY ET-QT TY-PQ QT-AP PQ-AB AB-BG BD-GQ BG-PQ AP-QT PQ-GH QT-H7",
            "2G-GQ QT-ET DE-CD CD-MN CM-NX NX-VX UV-QV GQ-NX NX-CM MN-CD CD-DE ET-QT QV-UV VX-PU PU-PM CM-PU UV-MN PM-N8",
            "CM-WY 3M-JY WY-CM MW-AC CM-MW MW-WY JY-GJ FG-AF AC-FP PQ-FG FP-AC GJ-JY WY-MW MW-CM AF-MN AC-MW CM-WY JY-3M WY-N8",
            "2F-AF AC-CM CM-KM KM-KU UW-KM KU-CM CM-AC AF-FK KM-CM AC-KM CM-KU KM-UW FK-WX WX-XY XY-TY QT-ET TY-XY XY-WX WX-FK UW-KM KU-CM KM-AC CM-KM FK-AF AC-CM KM-CE CM-AC ET-FI AC-I7", // 40
        };*/

        /// <summary>
        ///     Словарь соотношения символа исходного уровня с позицией на игровой карте
        /// </summary>
        public static Dictionary<string, LevelPoint> MapPoints { get; } = new Dictionary<string, LevelPoint>
        {
            { "1", new LevelPoint(6, 0)},
            { "2", new LevelPoint(6, 1)},
            { "3", new LevelPoint(6, 2)},
            { "4", new LevelPoint(6, 3)},
            { "5", new LevelPoint(6, 4)},
            { "6", new LevelPoint(0, 0)},
            { "7", new LevelPoint(0, 1)},
            { "8", new LevelPoint(0, 2)},
            { "9", new LevelPoint(0, 3)},
            { "A", new LevelPoint(5, 0)},
            { "B", new LevelPoint(4, 0)},
            { "C", new LevelPoint(3, 0)},
            { "D", new LevelPoint(2, 0)},
            { "E", new LevelPoint(1, 0)},
            { "F", new LevelPoint(5, 1)},
            { "G", new LevelPoint(4, 1)},
            { "H", new LevelPoint(3, 1)},
            { "I", new LevelPoint(2, 1)},
            { "J", new LevelPoint(1, 1)},
            { "K", new LevelPoint(5, 2)},
            { "L", new LevelPoint(4, 2)},
            { "M", new LevelPoint(3, 2)},
            { "N", new LevelPoint(2, 2)},
            { "O", new LevelPoint(1, 2)},
            { "P", new LevelPoint(5, 3)},
            { "Q", new LevelPoint(4, 3)},
            { "R", new LevelPoint(3, 3)},
            { "S", new LevelPoint(2, 3)},
            { "T", new LevelPoint(1, 3)},
            { "U", new LevelPoint(5, 4)},
            { "V", new LevelPoint(4, 4)},
            { "W", new LevelPoint(3, 4)},
            { "X", new LevelPoint(2, 4)},
            { "Y", new LevelPoint(1, 4)},
            { "Z", new LevelPoint(0, 4)}
        };
    }
}
