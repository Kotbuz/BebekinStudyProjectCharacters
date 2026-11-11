using Microsoft.AspNetCore.Mvc;
using StudyProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace StudyProject.Controllers
{
    public class CharactersController : Controller
    {
        private static List<CharacterModel> _characters = new List<CharacterModel>
            {
               new CharacterModel { Id = 1, Name = "Abrams", Species = "Ixian", Description = "Один из лучших частных детективов в \"Проклятом Яблоке\". Ищет способ как избавиться от проклятого тома раз и навсегда.", Level = 47 },
new CharacterModel { Id = 2, Name = "Apollo", Species = "Unknown", Description = "Загадочный стрелок, чьё прошлое скрыто за пеленой звёздной пыли. Говорит, что явился с небес, но никто не видел его крыльев.", Level = 63 },
new CharacterModel { Id = 3, Name = "Bebop", Species = "Robot", Description = "Списанный с фабрики рабочий робот, который обрёл сознание после удара молнии. Теперь он чинит не машины, а судьбы — кулаками.", Level = 22 },
new CharacterModel { Id = 4, Name = "Billy", Species = "Unknown", Description = "Вечный подросток с рогаткой и скверным характером. Утверждает, что ему сотни лет, но ведёт себя как двенадцатилетний.", Level = 8 },
new CharacterModel { Id = 5, Name = "Calico", Species = "Human", Description = "Хладнокровная наёмница с кошачьей грацией. Её контракты всегда выполняются — даже если цель этого не хочет.", Level = 71 },
new CharacterModel { Id = 6, Name = "Doorman", Species = "Unknown", Description = "Древняя и могущественная сущность из другого мира, что притворятся обычным держателем дверей в отеле Barroness.", Level = 94 },
new CharacterModel { Id = 7, Name = "Drifter", Species = "Vampire", Description = "Странствующий вампир, который пьёт не кровь, а воспоминания. Чем больше он странствует, тем меньше помнит о себе.", Level = 55 },
new CharacterModel { Id = 8, Name = "Dynamo", Species = "Unknown", Description = "Ходячая электростанция в человеческом облике. Его сердце — реактор, а слова — разряды. Опасно подходить близко в плохую погоду.", Level = 39 },
new CharacterModel { Id = 9, Name = "Graves", Species = "Human", Description = "Могильщик по профессии и по призванию. Знает о мёртвых больше, чем живые знают о себе. Никогда не задаёт лишних вопросов.", Level = 66 },
new CharacterModel { Id = 10, Name = "Grey Talon", Species = "Human", Description = "Старый охотник, чьи стрелы помнят вкус крови древних чудовищ. Говорит мало, стреляет метко, сожалеет о многом.", Level = 82 },
new CharacterModel { Id = 11, Name = "Haze", Species = "Human", Description = "Танцовщица из мира снов, которая научилась убивать во сне. Её враги засыпают и больше не просыпаются.", Level = 58 },
new CharacterModel { Id = 12, Name = "Holliday", Species = "Human", Description = "Шериф с Дикого Запада, случайно попавшая в «Проклятое Яблоко». Ищет путь домой, но сначала — наведёт порядок.", Level = 44 },
new CharacterModel { Id = 13, Name = "Infernus", Species = "Ixian", Description = "Пламенный проповедник, несущий слово огня. Считает, что мир нужно очистить пеплом, и начинает с ближайшего бара.", Level = 51 },
new CharacterModel { Id = 14, Name = "Ivy", Species = "Gargoyle", Description = "Горгулья, которая устала сидеть на крышах и решила спуститься к людям. Теперь охраняет не собор, а случайных прохожих.", Level = 35 },
new CharacterModel { Id = 15, Name = "Kelvin", Species = "Unknown", Description = "Ледяной странник, чьё дыхание замораживает время. Ищет тепло, которое растопит его сердце — или хотя бы чашку кофе.", Level = 60 },
new CharacterModel { Id = 16, Name = "Lady Geist", Species = "Human", Description = "Аристократка, продавшая душу ради красоты и власти. Теперь её тень живёт отдельной жизнью и иногда голосует против неё.", Level = 77 },
new CharacterModel { Id = 17, Name = "Lash", Species = "Human", Description = "Кнут без хозяина и совести. Работает на того, кто больше платит, и наслаждается каждым ударом.", Level = 29 },
new CharacterModel { Id = 18, Name = "McGinnis", Species = "Human", Description = "Инженер-самоучка с гаражом, полным турелей и нереализованных идей. Если что-то сломалось — она это починит. Или взорвёт.", Level = 41 },
new CharacterModel { Id = 19, Name = "Mina", Species = "Vampire", Description = "Вампирша-аристократка, которая коллекционирует не жертв, а истории. Её укус оставляет не раны, а вдохновение.", Level = 68 },
new CharacterModel { Id = 20, Name = "Mirage", Species = "Human", Description = "Мастер иллюзий, который сам уже не помнит, где настоящее «я». Продаёт миражи доверчивым и сны — отчаявшимся.", Level = 52 },
new CharacterModel { Id = 21, Name = "Mo & Krill", Species = "Unknown", Description = "Две сущности в одном теле: крот-мечтатель и крот-реалист. Спорят обо всём, но в драке действуют как единый механизм.", Level = 33 },
new CharacterModel { Id = 22, Name = "Paige", Species = "Human", Description = "Библиотекарь, чьи книги умеют кусаться. Знает, где спрятан каждый секрет «Проклятого Яблока», но выдаёт их только по читательскому билету.", Level = 26 },
new CharacterModel { Id = 23, Name = "Paradox", Species = "Human", Description = "Ходячее противоречие: одновременно здесь и там, сейчас и тогда. Говорит загадками, но всегда оказывается права. Или нет.", Level = 88 },
new CharacterModel { Id = 24, Name = "Pocket", Species = "Human", Description = "Карманник, который крадёт не вещи, а удачу. После встречи с ним вы обязательно что-нибудь потеряете — но не заметите этого.", Level = 19 },
new CharacterModel { Id = 25, Name = "Seven", Species = "Human", Description = "Седьмой сын седьмого сына, несущий семь проклятий. Считает до семи всегда, даже когда стреляет.", Level = 73 },
new CharacterModel { Id = 26, Name = "Shiv", Species = "Human", Description = "Уличный боец с обострённым чувством справедливости и заточенной отверткой. Решает споры быстро и необратимо.", Level = 37 },
new CharacterModel { Id = 27, Name = "Sinclair", Species = "Unknown", Description = "Дворецкий, который всегда появляется вовремя и всегда знает чуть больше, чем следует. Его чай подозрительно вкусный.", Level = 91 },
new CharacterModel { Id = 28, Name = "Victor", Species = "Human", Description = "Бывший врач, ставший охотником на нечисть. Лечит тех, кого ещё можно спасти, и добивает тех, кого уже нет.", Level = 49 },
new CharacterModel { Id = 29, Name = "Vindicta", Species = "Ghost", Description = "Призрак ведьмы, сожжённой на костре. Её месть длится уже триста лет, и она не собирается останавливаться.", Level = 85 },
new CharacterModel { Id = 30, Name = "Viscous", Species = "Unknown", Description = "Слизистая форма жизни, которая обрела разум и очень хочет быть полезной. Обнимает крепко — иногда слишком.", Level = 14 },
new CharacterModel { Id = 31, Name = "Vyper", Species = "Unknown", Description = "Змеелюд с ядовитым языком и обаятельной улыбкой. Торгует антидотами собственного производства — и ядом тоже.", Level = 56 },
new CharacterModel { Id = 32, Name = "Warden", Species = "Human", Description = "Тюремщик, который сам сидел в клетке дольше, чем его подопечные. Теперь он решает, кто достоин свободы.", Level = 62 },
new CharacterModel { Id = 33, Name = "Wraith", Species = "Human", Description = "Медиум, вызывающий духов для развлечения публики. Иногда духи отказываются уходить обратно.", Level = 45 },
new CharacterModel { Id = 34, Name = "Yamato", Species = "Human", Description = "Мечница из далёкой восточной страны, чей клинок рассекает не только плоть, но и карму. Ищет достойного противника.", Level = 79 }
            };


        // GET: Characters
        public IActionResult Index()
        {
            // Mock data for demonstration
            return View(_characters);
        }

        // GET: Characters/GetDetails/{id}
        [HttpGet]
        public ActionResult GetDetails(int id)
        {
            return Json(_characters.First(c => c.Id == id));
        }

        // GET: Characters/Editor/
        public IActionResult Editor()
        {
            var character = new CharacterModel { Id = _characters.Last().Id + 1, Level = 1 };
            return View(character);
        }

        public IActionResult PartialEditor(int id)
        {
            var character = _characters.First(c => c.Id == id);
            return PartialView("_CharacterEditor", character);
        }


        // POST: Characters/PostCreate
        [HttpPost]
        public IActionResult PostCreate(CharacterModel character)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Editor));
            }
            _characters.Add(character);
            return RedirectToAction(nameof(Index));
        }
    }
}
