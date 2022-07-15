using KTZEngine;
using System.Collections.Generic;

namespace KillTheZGame
{
    public class GameLanguages
    {
        public static void Init()
        {
            GameData.aplication.gameText = new GameText(GameData.ukraine.name, new List<Language>() { GameData.english, GameData.ukraine, GameData.polish });
            GameData.aplication.gameText.AddSomeText(new Dictionary<string, Dictionary<string, string>>()
            {
                {"MainMenu", new Dictionary<string, string>() { { GameData.english.name, "Main Menu" }, { GameData.ukraine.name, "Головне Меню" }, { GameData.polish.name, "Menu Główne" } } },
                {"StartGame", new Dictionary<string, string>() { { GameData.english.name, "New Game" }, { GameData.ukraine.name, "Нова гра" }, { GameData.polish.name, "Nowa gra" } } },
                {"ContinueGame", new Dictionary<string, string>() { { GameData.english.name, "Continue Game" }, { GameData.ukraine.name, "Продовжити Гру" }, { GameData.polish.name, "Kontynuuj grę" } } },
                {"Tutorial", new Dictionary<string, string>() { { GameData.english.name, "Tutorial" }, { GameData.ukraine.name, "Підручник" }, { GameData.polish.name, "Podręcznik" } } },
                {"Settings", new Dictionary<string, string>() { { GameData.english.name, "Settings" }, { GameData.ukraine.name, "Налаштування" }, { GameData.polish.name, "Ustawienia" } } },
                {"Credits", new Dictionary<string, string>() { { GameData.english.name, "Credits" }, { GameData.ukraine.name, "Автори" }, { GameData.polish.name, "Autorski" } } },
                {"Exit", new Dictionary<string, string>() { { GameData.english.name, "Exit" }, { GameData.ukraine.name, "Вихід" }, { GameData.polish.name, "Wyjście" } } },

                {"NowDecideFatemoscow", new Dictionary<string, string>() { { GameData.english.name, "Now you must decide fate of moscow" }, { GameData.ukraine.name, "Тепер вам належить вирішити долю москви" }, { GameData.polish.name, "Teraz musisz zdecydować o losie Moskwy" } } },


                {"FateDestroymoscow", new Dictionary<string, string>() { { GameData.english.name, "Destroy [ plus 100000 to score ]" }, { GameData.ukraine.name, "Стрерти з лиця землі [ плюс 100000 до очок ]" }, { GameData.polish.name, "Zniszcz [ plus 100000 do wynik ]" } } },
                {"FateUkrainianizemoscow", new Dictionary<string, string>() { { GameData.english.name, "Ukrainianize [ colony will multiply score by 1.3 times ]" }, { GameData.ukraine.name, "Українізувати [ колонія примножить очки у 1.3 рази ]" }, { GameData.polish.name, "Ukrainizuj [ kolonia pomnoży wynik 1,3 razy ]" } } },


                {"GameTheme", new Dictionary<string, string>() { { GameData.english.name, "Game Theme:" }, { GameData.ukraine.name, "Тема гри:" }, { GameData.polish.name, "Motyw gry:" } } },

                {"ThemeDark", new Dictionary<string, string>() { { GameData.english.name, "Dark" }, { GameData.ukraine.name, "Темна" }, { GameData.polish.name, "Ciemny" } } },
                {"ThemeLight", new Dictionary<string, string>() { { GameData.english.name, "Light" }, { GameData.ukraine.name, "Світла" }, { GameData.polish.name, "Światła" } } },
                {"ThemeBloodMoon", new Dictionary<string, string>() { { GameData.english.name, "Blood Moon" }, { GameData.ukraine.name, "Кривавий місяць" }, { GameData.polish.name, "Krwawy Księżyc" } } },
                {"ThemeHell", new Dictionary<string, string>() { { GameData.english.name, "Hell" }, { GameData.ukraine.name, "Пекло" }, { GameData.polish.name, "Piekło" } } },
                {"ThemeHecker", new Dictionary<string, string>() { { GameData.english.name, "Hecker" }, { GameData.ukraine.name, "Хакер" }, { GameData.polish.name, "Haker" } } },
                {"ThemePatriotic", new Dictionary<string, string>() { { GameData.english.name, "Patriotic" }, { GameData.ukraine.name, "Патріотична" }, { GameData.polish.name, "Patriotyczny" } } },
                {"MyLittlePony", new Dictionary<string, string>() { { GameData.english.name, "MyLittlePony" }, { GameData.ukraine.name, "MyLittlePony" }, { GameData.polish.name, "MyLittlePony" } } },

                {"GameLanguage", new Dictionary<string, string>() { { GameData.english.name, "Game Language:" }, { GameData.ukraine.name, "Мова гри:" }, { GameData.polish.name, "Język gry:" } } },
                {"ClearGameProgress", new Dictionary<string, string>() { { GameData.english.name, "Clear Game Progress" }, { GameData.ukraine.name, "Видалити Ігровий Прогрес" }, { GameData.polish.name, "Wyczyść postęp gry" } } },

                {"PressEnterSpaceDeleteData", new Dictionary<string, string>() { { GameData.english.name, "Press Enter or Space to clear game progress" }, { GameData.ukraine.name, "Натисніть Enter або Space(Укр.Пробіл) щоб очистити прогрес гри" }, { GameData.polish.name, "Naciśnij Enter lub spację, aby wyczyścić postęp gry" } } },
                {"DonateZSU", new Dictionary<string, string>() { { GameData.english.name, "Donate to the Armed Forces of Ukraine" }, { GameData.ukraine.name, "Пожертва для ЗСУ" }, { GameData.polish.name, "Darowizna dla Sił Zbrojnych Ukrainy" } } },

                {"NationalBank", new Dictionary<string, string>() { { GameData.english.name, "National Bank" }, { GameData.ukraine.name, "Національний банк" }, { GameData.polish.name, "Bank Narodowy" } } },
                {"ComeBackAlive", new Dictionary<string, string>() { { GameData.english.name, "Charitable fund \"Come back alive\"" }, { GameData.ukraine.name, "Благодійний фонд «Повернись живим»" }, { GameData.polish.name, "Fundusz charytatywny \"Wróć żywy\"" } } },
                {"Hospitallers", new Dictionary<string, string>() { { GameData.english.name, "Medical Battalion \"Hospitallers\"" }, { GameData.ukraine.name, "Медичний батальйон \"Госпітальєри\"" }, { GameData.polish.name, "Batalion Medyczny \"Hospitallers\"" } } },


                {"YouLost", new Dictionary<string, string>() { { GameData.english.name, "You lost the city" }, { GameData.ukraine.name, "Ви втратили місто" }, { GameData.polish.name, "Straciłeś miasto" } } },
                {"Congratulations", new Dictionary<string, string>() { { GameData.english.name, "Congratulations" }, { GameData.ukraine.name, "Вітаємо" }, { GameData.polish.name, "Gratulacje" } } },
                {"YouWin", new Dictionary<string, string>() { { GameData.english.name, "You have captured the city" }, { GameData.ukraine.name, "Ви захопили місто" }, { GameData.polish.name, "Zdobyłeś miasto" } } },

                {"Today", new Dictionary<string, string>() { { GameData.english.name, "Today " }, { GameData.ukraine.name, "Сьогодні " }, { GameData.polish.name, "Dziś " } } },
                {"IsHistoricDay", new Dictionary<string, string>() { { GameData.english.name, " is a historic day" }, { GameData.ukraine.name, " - історичний день" }, { GameData.polish.name, " - historyczny dzień" } } },
                {"YouCapturemoscow", new Dictionary<string, string>() { { GameData.english.name, "Today you capture moscow" }, { GameData.ukraine.name, "Сьогодні ви захопили москву" }, { GameData.polish.name, "Dziś zdobywasz moskwę" } } },
                {"YouFinWinWar", new Dictionary<string, string>() { { GameData.english.name, "and you finally won the war that started in " }, { GameData.ukraine.name, "і ви нарешті виграли війну, яка почалася " }, { GameData.polish.name, "i w końcu wygrałeś wojnę, która zaczęła się w " } } },

                {"StartWar1", new Dictionary<string, string>() { { GameData.english.name, "All the destroyed cities were rebuilt and the people returned home" }, { GameData.ukraine.name, "Всі зруйновані міста були відбудовані, а люди повернуті додому" }, { GameData.polish.name, "Wszystkie zniszczone miasta zostały odbudowane, a ludzie wrócili do domów" } } },
                {"StartWar2", new Dictionary<string, string>() { { GameData.english.name, "And everyone lived well, until " }, { GameData.ukraine.name, "І усі жили добре, до " }, { GameData.polish.name, "I wszyscy żyli dobrze, do " } } },
                {"StartWar3", new Dictionary<string, string>() { { GameData.english.name, "On this day, a group of religious and political fanatics led by the leader," }, { GameData.ukraine.name, "Цього дня група релігійно-політичних фанатиків на чолі з вождем," }, { GameData.polish.name, "W tym dniu grupa fanatyków religijnych i politycznych pod przewodnictwem przywódcy" } } },
                {"StartWar4", new Dictionary<string, string>() { { GameData.english.name, "which have recently begun to gather in flocks in northeastern Asia," }, { GameData.ukraine.name, "які недавно почали збиратися зграями в північно-східній частині Азії," }, { GameData.polish.name, "które niedawno zaczęły gromadzić się w stada w północno-wschodniej Azji," } } },
                {"StartWar5", new Dictionary<string, string>() { { GameData.english.name, "decided that they did not like neighbors better than them" }, { GameData.ukraine.name, "вирішили, що їм не подобаються сусіди, кращі за них" }, { GameData.polish.name, "uznali, że nie lubią sąsiadów bardziej od nich" } } },
                {"StartWar6", new Dictionary<string, string>() { { GameData.english.name, "and began to partially seize the territory of our Ukraine." }, { GameData.ukraine.name, "і почали почастинно загарбувати території нашої України." }, { GameData.polish.name, "i zaczął częściowo zajmować terytorium naszej Ukrainy." } } },
                {"StartWar7", new Dictionary<string, string>() { { GameData.english.name, "This time, the Ukrainians knew whose descendants they were and did not wait long to fight back." }, { GameData.ukraine.name, "Цього разу, українці знали чиї це нащадки і довго не чекали щоб дати відсіч." }, { GameData.polish.name, "Tym razem Ukraińcy wiedzieli, czyimi są potomkami i nie czekali długo z odwetem." } } },
                {"StartWar8", new Dictionary<string, string>() { { GameData.english.name, "Because there were so many fanatics and they didn't care about their lives," }, { GameData.ukraine.name, "Оскільки фанатиків було дуже багато і їм було байдуже на свої життя," }, { GameData.polish.name, "Ponieważ było tak wielu fanatyków i nie dbali o swoje życie," } } },
                {"StartWar9", new Dictionary<string, string>() { { GameData.english.name, "people who remember the history that a similar situation had already occurred" }, { GameData.ukraine.name, "люди памятаючі історію згадали, що схожа ситуація вже відбувалася" }, { GameData.polish.name, "osoby, które pamiętają historię, że podobna sytuacja już miała miejsce" } } },
                {"StartWar10", new Dictionary<string, string>() { { GameData.english.name, "and in a few days they found you in warehouses - artificial intelligence," }, { GameData.ukraine.name, "і за кілька днів знайшли на складах вас - штучний інтелект," }, { GameData.polish.name, "i za kilka dni znaleźli cię w magazynach - sztuczna inteligencja," } } },
                {"StartWar11", new Dictionary<string, string>() { { GameData.english.name, "which was developed earlier by professional Ukrainian programmers" }, { GameData.ukraine.name, "який був розроблений давніше професійними українськими програмістами" }, { GameData.polish.name, "który został opracowany wcześniej przez profesjonalnych ukraińskich programistów" } } },
                {"StartWar12", new Dictionary<string, string>() { { GameData.english.name, "and launched into the latest combat vehicle" }, { GameData.ukraine.name, "і запущений у новітню бойову машину" }, { GameData.polish.name, "i wprowadzony do najnowszego pojazdu bojowego" } } },
                {"StartWar13", new Dictionary<string, string>() { { GameData.english.name, "specifically for the extermination of large groups of orcs." }, { GameData.ukraine.name, "спеціально для винищення великих груп орків." }, { GameData.polish.name, "specjalnie do eksterminacji dużych grup orków." } } },
                {"StartWar14", new Dictionary<string, string>() { { GameData.english.name, "Now your new task is to capture the most important place of their accumulation," }, { GameData.ukraine.name, "Тепер ваша нова задача - це захопити найважливіше місце їхнього скупчення," }, { GameData.polish.name, "Teraz Twoim nowym zadaniem jest uchwycenie najważniejszego miejsca ich akumulacji," } } },
                {"StartWar15", new Dictionary<string, string>() { { GameData.english.name, "namely, a multi-kilometer open temple with a fanatically chosen name - moscow" }, { GameData.ukraine.name, "а саме багатокілометровий відкритий храм із фанатично підібраною назвою - москва" }, { GameData.polish.name, "a mianowicie wielokilometrowa otwarta świątynia o fanatycznie wybranej nazwie - moskwa" } } },
                {"StartWar16", new Dictionary<string, string>() { { GameData.english.name, "Good luck!" }, { GameData.ukraine.name, "Удачі!" }, { GameData.polish.name, "Powodzenia!" } } },

                {"Programmer", new Dictionary<string, string>() { { GameData.english.name, "Programmer" }, { GameData.ukraine.name, "Програміст" }, { GameData.polish.name, "Programista" } } },
                {"MainTesters", new Dictionary<string, string>() { { GameData.english.name, "Main testers" }, { GameData.ukraine.name, "Головні тестери" }, { GameData.polish.name, "Główni testerzy" } } },
                {"UAtext", new Dictionary<string, string>() { { GameData.english.name, "Ukrainian texts" }, { GameData.ukraine.name, "Українські тексти" }, { GameData.polish.name, "Teksty ukraińskie" } } },
                {"ENtranslation", new Dictionary<string, string>() { { GameData.english.name, "English translation" }, { GameData.ukraine.name, "Англійський переклад" }, { GameData.polish.name, "Angielskie tłumaczenie" } } },
                {"POtranslation", new Dictionary<string, string>() { { GameData.english.name, "Polish translation" }, { GameData.ukraine.name, "Польський переклад" }, { GameData.polish.name, "Polskie tłumaczenie" } } },

                {"Translator", new Dictionary<string, string>() { { GameData.english.name, "Translator" }, { GameData.ukraine.name, "Перекладач" }, { GameData.polish.name, "Tłumacz" } } },


                {"PressEscape", new Dictionary<string, string>() { { GameData.english.name, "Press Escape to go back to menu" }, { GameData.ukraine.name, "Нажміть Escape щоб вийти в меню" }, { GameData.polish.name, "Naciśnij Escape, aby wrócić do menu" } } },
                {"PressEnter", new Dictionary<string, string>() { { GameData.english.name, "Press Enter or Space to continue game" }, { GameData.ukraine.name, "Нажміть Enter або Space(Укр.Пробіл) щоб продовжити гру" }, { GameData.polish.name, "Naciśnij Enter lub Space, aby kontynuować grę" } } },

                {"PressEnterToContinue", new Dictionary<string, string>() { { GameData.english.name, "Press Enter or Space to continue" }, { GameData.ukraine.name, "Нажміть Enter або Space(Укр.Пробіл) щоб продовжити" }, { GameData.polish.name, "Naciśnij Enter lub Space, aby kontynuować" } } },


                {"TutTitle", new Dictionary<string, string>() { { GameData.english.name, "KillTheZ tutorial" }, { GameData.ukraine.name, "KillTheZ підручник" }, { GameData.polish.name, "KillTheZ instruktaż" } } },
                {"SettTitle", new Dictionary<string, string>() { { GameData.english.name, "KillTheZ settings" }, { GameData.ukraine.name, "KillTheZ настройки" }, { GameData.polish.name, "KillTheZ ustawienia" } } },
                {"CreditsTitle", new Dictionary<string, string>() { { GameData.english.name, "KillTheZ credits" }, { GameData.ukraine.name, "KillTheZ автори" }, { GameData.polish.name, "KillTheZ autorski" } } },

                {"Tut1_2", new Dictionary<string, string>() { { GameData.english.name, "<Previous Page            1                Next Page>" }, { GameData.ukraine.name, "<Минула Сторінка                 1                Наступна Сторінка>" }, { GameData.polish.name, "<Poprzednia Strona            1                Następna Strona>" } } },
                {"Tut1_3", new Dictionary<string, string>() { { GameData.english.name, "────────────────── Mission ──────────────────" }, { GameData.ukraine.name, "────────────────── Місія ──────────────────" }, { GameData.polish.name, "────────────────── Misja ──────────────────" } } },
                {"Tut1_4", new Dictionary<string, string>() { { GameData.english.name, "You have only 2 main missions:" }, { GameData.ukraine.name, "У вас є тільки 2 основні місії:" }, { GameData.polish.name, "Masz tylko 2 główne misje:" } } },
                {"Tut1_5", new Dictionary<string, string>() { { GameData.english.name, "1) Capture moscow" }, { GameData.ukraine.name, "1) Захопити москву" }, { GameData.polish.name, "1) Uchwyć moskwę" } } },
                {"Tut1_6", new Dictionary<string, string>() { { GameData.english.name, "2) Collect more scores" }, { GameData.ukraine.name, "2) Назбирати більше очок" }, { GameData.polish.name, "2) Zbierz więcej wyników" } } },
                {"Tut1_7", new Dictionary<string, string>() { { GameData.english.name, "Good luck!" }, { GameData.ukraine.name, "Удачі!" }, { GameData.polish.name, "Good luck" } } },

                {"Tut2_2", new Dictionary<string, string>() { { GameData.english.name, "<Previous Page            2                Next Page>" }, { GameData.ukraine.name, "<Минула Сторінка                 2                Наступна Сторінка>" }, { GameData.polish.name, "<Poprzednia Strona            2                Następna Strona>" } } },
                {"Tut2_3", new Dictionary<string, string>() { { GameData.english.name, "────────────────── Player Control ──────────────────" }, { GameData.ukraine.name, "────────────────── Керування гравцем ──────────────────" }, { GameData.polish.name, "────────────────── Kontrola Gracza ──────────────────" } } },
                {"Tut2_4", new Dictionary<string, string>() { { GameData.english.name, "Player" }, { GameData.ukraine.name, "Гравець" }, { GameData.polish.name, "Player" } } },
                {"Tut2_5", new Dictionary<string, string>() { { GameData.english.name, "Press D or Right Arrow to move right" }, { GameData.ukraine.name, "Нажміть D(Укр.В) або Стрілку Вправо щоб рухатися праворуч" }, { GameData.polish.name, "Naciśnij D lub strzałkę w prawo, aby przejść w prawo" } } },
                {"Tut2_7", new Dictionary<string, string>() { { GameData.english.name, "Press A or Left Arrow to move left" }, { GameData.ukraine.name, "Нажміть A(Укр.Ф) або Стрілку Вліво щоб рухатися ліворуч" }, { GameData.polish.name, "Naciśnij A lub strzałkę w lewo, aby przejść w lewo" } } },
                {"Tut2_9", new Dictionary<string, string>() { { GameData.english.name, "Press W or Up Arrow to move up" }, { GameData.ukraine.name, "Нажміть W(Укр.Ц) або Стрілку Вгору щоб рухатися вгору" }, { GameData.polish.name, "Naciśnij W lub strzałkę w górę, aby przejść w górę" } } },
                {"Tut2_11", new Dictionary<string, string>() { { GameData.english.name, "Press S or Down Arrow to move down" }, { GameData.ukraine.name, "Нажміть S(Укр.І) або Стрілку Вниз щоб рухатися вниз" }, { GameData.polish.name, "Naciśnij S lub strzałkę w dół, aby przejść w dół" } } },
                {"Tut2_13", new Dictionary<string, string>() { { GameData.english.name, "Press Space to shoot" }, { GameData.ukraine.name, "Нажміть Space(Укр.Пробіл) щоб стріляти" }, { GameData.polish.name, "Naciśnij Space, aby strzelać" } } },
                {"Tut2_15", new Dictionary<string, string>() { { GameData.english.name, "Press E to plant a mine" }, { GameData.ukraine.name, "Нажміть E(Укр.У) щоб встановити міну" }, { GameData.polish.name, "Naciśnij E, aby umieścić mój" } } },
                {"Tut2_17", new Dictionary<string, string>() { { GameData.english.name, "Press Q to start Bayraktar attack" }, { GameData.ukraine.name, "Нажміть Q(Укр.Й) щоб почати атаку Байрактарів" }, { GameData.polish.name, "Naciśnij Q, aby rozpocząć atak Bayraktara" } } },

                {"Tut3_2", new Dictionary<string, string>() { { GameData.english.name, "<Previous Page            3                Next Page>" }, { GameData.ukraine.name, "<Минула Сторінка                 3                Наступна Сторінка>" }, { GameData.polish.name, "<Poprzednia Strona            3                Następna Strona>" } } },
                {"Tut3_3", new Dictionary<string, string>() { { GameData.english.name, "────────────────── Companions ──────────────────" }, { GameData.ukraine.name, "────────────────── Напарники ──────────────────" }, { GameData.polish.name, "────────────────── Przyjaciele ──────────────────" } } },
                {"Tut3_4", new Dictionary<string, string>() { { GameData.english.name, "Tractor driver Mykola" }, { GameData.ukraine.name, "Тракторист Микола" }, { GameData.polish.name, "Kierowca ciągnika Mikołaj" } } },
                {"Tut3_6", new Dictionary<string, string>() { { GameData.english.name, "Tractor driver Mykola can easily eat enemy tanks with his tractor" }, { GameData.ukraine.name, "Тракторист Микола своїм трактором може з легкістю їсти ворожі танки" }, { GameData.polish.name, "Traktor Mykoła może z łatwością pożreć wrogie czołgi swoim traktorem" } } },
                {"Tut3_7", new Dictionary<string, string>() { { GameData.english.name, "He is usually slow and calm," }, { GameData.ukraine.name, "Зазвичай він повільний і спокійний," }, { GameData.polish.name, "Jest zwykle powolny i spokojny," } } },
                {"Tut3_8", new Dictionary<string, string>() { { GameData.english.name, "but when he notices an enemy tank, that will change" }, { GameData.ukraine.name, "але коли він помітить ворожий танк, це зміниться" }, { GameData.polish.name, "ale kiedy zauważy wrogi czołg, to się zmieni" } } },
                {"Tut3_9", new Dictionary<string, string>() { { GameData.english.name, "Ukrainian soldiers" }, { GameData.ukraine.name, "Українські солдати" }, { GameData.polish.name, "Żołnierze ukraińscy" } } },
                {"Tut3_11", new Dictionary<string, string>() { { GameData.english.name, "Valiant heroes who protect civilians from orcs" }, { GameData.ukraine.name, "Доблесні герої які захищають цивільних людей від орків" }, { GameData.polish.name, "Dzielni bohaterowie, którzy chronią cywilów przed orkami" } } },
                {"Tut3_12", new Dictionary<string, string>() { { GameData.english.name, "These daredevils can:" }, { GameData.ukraine.name, "Ці сміливці можуть:" }, { GameData.polish.name, "Ci śmiałkowie mogą:" } } },
                {"Tut3_13", new Dictionary<string, string>() { { GameData.english.name, "1) Shoot the enemies at a distance of up to " }, { GameData.ukraine.name, "1) Стріляти у ворогів на відстані до " }, { GameData.polish.name, "1) Strzelaj do wrogów z odległości do " } } },
                {"Tut3_14", new Dictionary<string, string>() { { GameData.english.name, "2) Plant on the map flashing surprises for enemies" }, { GameData.ukraine.name, "2) Ставити на карті миготливі сюрпризи для ворогів" }, { GameData.polish.name, "2) Posadź na mapie migające niespodzianki dla wrogów" } } },

                {"Tut4_2", new Dictionary<string, string>() { { GameData.english.name, "<Previous Page            4                Next Page>" }, { GameData.ukraine.name, "<Минула Сторінка                 4                Наступна Сторінка>" }, { GameData.polish.name, "<Poprzednia Strona            4                Następna Strona>" } } },
                {"Tut4_3", new Dictionary<string, string>() { { GameData.english.name, "────────────────── Enemy ──────────────────" }, { GameData.ukraine.name, "────────────────── Вороги ──────────────────" }, { GameData.polish.name, "────────────────── Wrogowie ──────────────────" } } },
                {"Tut4_4", new Dictionary<string, string>() { { GameData.english.name, "Shitty russian tank" }, { GameData.ukraine.name, "Лайняні російські танки" }, { GameData.polish.name, "Gówniane rosyjskie czołgi" } } },
                {"Tut4_6", new Dictionary<string, string>() { { GameData.english.name, "These tanks are cans that can barely drive" }, { GameData.ukraine.name, "Ці танки - це бляшанки, які ледве можуть їхати" }, { GameData.polish.name, "Te zbiorniki to puszki, które ledwo się poruszają" } } },
                {"Tut4_7", new Dictionary<string, string>() { { GameData.english.name, "They can't do anything advanced to Ukrainian vehicles," }, { GameData.ukraine.name, "Вони не можуть зашкодити просунутій українській техніці," }, { GameData.polish.name, "Nie mogą zaszkodzić zaawansowanej ukraińskiej technologii," } } },
                {"Tut4_8", new Dictionary<string, string>() { { GameData.english.name, "and the only thing they realy can do is destroy a car" }, { GameData.ukraine.name, "і єдине, що вони реально можуть - це переїхати легкове авто," }, { GameData.polish.name, "a jedyne, co naprawdę mogą zrobić, to ruszyć samochodem," } } },
                {"Tut4_9", new Dictionary<string, string>() { { GameData.english.name, "or drive to civilians in the yard" }, { GameData.ukraine.name, "або заїхати у двір мирним людям" }, { GameData.polish.name, "lub jedź do cywilów na podwórku" } } },

                {"Tut5_2", new Dictionary<string, string>() { { GameData.english.name, "<Previor Page            5                Next Page>" }, { GameData.ukraine.name, "<Минула Сторінка                 5                Наступна Сторінка>" }, { GameData.polish.name, "<Poprzednia Strona            5                Następna Strona>" } } },
                {"Tut5_3", new Dictionary<string, string>() { { GameData.english.name, "────────────────── Objects on map ──────────────────" }, { GameData.ukraine.name, "────────────────── Об'єкти на карті ──────────────────" }, { GameData.polish.name, "────────────────── Obiekty na mapie ──────────────────" } } },
                {"Tut5_4", new Dictionary<string, string>() { { GameData.english.name, "House" }, { GameData.ukraine.name, "Будинок" }, { GameData.polish.name, "Dom" } } },
                {"Tut5_6", new Dictionary<string, string>() { { GameData.english.name, "A simple house used as a wall" }, { GameData.ukraine.name, "Простий будинок, який використовується як стіна" }, { GameData.polish.name, "Prosty dom używany jako ściana" } } },
                {"Tut5_7", new Dictionary<string, string>() { { GameData.english.name, "City important zone" }, { GameData.ukraine.name, "Важлива міська зона" }, { GameData.polish.name, "Ważna strefa miasta" } } },
                {"Tut5_9", new Dictionary<string, string>() { { GameData.english.name, "Enemy spawns on top zone" }, { GameData.ukraine.name, "Вороги зявляються у верхній зоні" }, { GameData.polish.name, "Wróg pojawia się w górnej strefie" } } },
                {"Tut5_10", new Dictionary<string, string>() { { GameData.english.name, "If enemy reach the bottom zone you lose the current city" }, { GameData.ukraine.name, "Якщо ворог досягне нижньої зони, ви втрачаєте поточне місто" }, { GameData.polish.name, "Jeśli wróg dotrze do dolnej strefy, tracisz obecne miasto" } } },
                {"Tut5_11", new Dictionary<string, string>() { { GameData.english.name, "Crater" }, { GameData.ukraine.name, "Кратер" }, { GameData.polish.name, "Krater" } } },
                {"Tut5_13", new Dictionary<string, string>() { { GameData.english.name, "Consequences of the explosion of ruscists missiles" }, { GameData.ukraine.name, "Наслідки вибуху рашистських ракет" }, { GameData.polish.name, "Konsekwencje wybuchu rasistowskich pocisków" } } },
                {"Tut5_14", new Dictionary<string, string>() { { GameData.english.name, "Slows down enemies and your soldiers" }, { GameData.ukraine.name, "Сповільнює ворогів і ваших солдатів" }, { GameData.polish.name, "Spowalnia wrogów i żołnierzy" } } },
                {"Tut5_15", new Dictionary<string, string>() { { GameData.english.name, "Hedgehog" }, { GameData.ukraine.name, "Їжачок" }, { GameData.polish.name, "Jeż" } } },
                {"Tut5_17", new Dictionary<string, string>() { { GameData.english.name, "Very useful thing" }, { GameData.ukraine.name, "Дуже корисна штука" }, { GameData.polish.name, "Bardzo przydatna rzecz" } } },
                {"Tut5_18", new Dictionary<string, string>() { { GameData.english.name, "Biolaboratory" }, { GameData.ukraine.name, "Біолабораторія" }, { GameData.polish.name, "Biolaboratorium" } } },
                {"Tut5_20", new Dictionary<string, string>() { { GameData.english.name, "A very common thing in the Ukrainian lands" }, { GameData.ukraine.name, "Дуже поширена річ в Українських краях" }, { GameData.polish.name, "Bardzo powszechna rzecz na ziemiach ukraińskich" } } },

                {"MineCount", new Dictionary<string, string>() { { GameData.english.name, "    Mine count: " }, { GameData.ukraine.name, "Кількість мін: " }, { GameData.polish.name, "Liczba kopalni: " } } },
                {"BayraktarAttackCount", new Dictionary<string, string>() { { GameData.english.name, "    Bayraktar attack count: " }, { GameData.ukraine.name, "    Доступно атак Байрактарів: " }, { GameData.polish.name, "    Liczba ataków Bayraktara: " } } },
                {"CurrentTime", new Dictionary<string, string>() { { GameData.english.name, "Current Time: " }, { GameData.ukraine.name, "Поточний час: " }, { GameData.polish.name, "Obecny czas: " } } },
                {"ms", new Dictionary<string, string>() { { GameData.english.name, "ms" }, { GameData.ukraine.name, "мс" }, { GameData.polish.name, "ms" } } },
                {"AttackStartTime", new Dictionary<string, string>() { { GameData.english.name, "    Attack start time: " }, { GameData.ukraine.name, "    Час початку наступу: " }, { GameData.polish.name, "    Czas rozpoczęcia ataku: " } } },
                {"EnemyLeftSpawn", new Dictionary<string, string>() { { GameData.english.name, "Enemy left to spawn: " }, { GameData.ukraine.name, "Ворогів прибуде: " }, { GameData.polish.name, "Wróg pozostawiony do odrodzenia: " } } },
                {"EnemyLeftKill", new Dictionary<string, string>() { { GameData.english.name, "    Enemy left to kill: " }, { GameData.ukraine.name, "    Ворогів залишилося вбити: " }, { GameData.polish.name, "   Wróg pozostawiony do zabicia: " } } },
                {"Score", new Dictionary<string, string>() { { GameData.english.name, "Score: " }, { GameData.ukraine.name, "Очки: " }, { GameData.polish.name, "Wynik: " } } },

                {"Yes", new Dictionary<string, string>() { { GameData.english.name, "Yes" }, { GameData.ukraine.name, "Так" }, { GameData.polish.name, "Tak" } } },
                {"No", new Dictionary<string, string>() { { GameData.english.name, "No" }, { GameData.ukraine.name, "Ні" }, { GameData.polish.name, "Nie" } } },

                {"NewGameQuestion", new Dictionary<string, string>() { { GameData.english.name, "Are you sure? You will lose progress on the current city" }, { GameData.ukraine.name, "Ви впевнені? Ви втратите прогрес на поточному місті" }, { GameData.polish.name, "Jesteś pewny? Stracisz postępy w obecnym mieście" } } },
                {"ExitGameQuestion", new Dictionary<string, string>() { { GameData.english.name, "Are you sure you want to exit? Unfinished levels will be lost" }, { GameData.ukraine.name, "Ви впевнені, що хочете вийти? Незакінчені рівні буду втрачені" }, { GameData.polish.name, "Czy jesteś pewny że chcesz wyjść? Niedokończone poziomy zostaną utracone" } } },
                {"ClearDataQuestion", new Dictionary<string, string>() { { GameData.english.name, "Are you sure you want to clear your progress? You will restart the game with default settings" }, { GameData.ukraine.name, "Ви впевнені, що хочете очистити прогрес? Ви почнете гру заново з стандартними настройками" }, { GameData.polish.name, "Czy na pewno chcesz wyczyścić postęp? Zrestartujesz grę z domyślnymi ustawieniami" } } },

            });

        }
    }
}
