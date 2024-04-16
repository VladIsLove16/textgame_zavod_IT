using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavod_IT_TextGame
{
    internal class SpecialRoom : Room
    {
        private int EnterCount=0;
        public new string EnterMessage
        {
            get
            {
                EnterCount++;
                if(EnterCount == 3)
                {
                    return "Вы уже в 3й раз оказались на Кухне";
                }
                if(EnterCount == 5) {
                    return "О, снова ты! Я вижу, ты опять пришел сюда, чтобы изучить уникальные законы физики, действующие на пустую холодильную полку.\"";
                }
                if(EnterCount == 8) {
                    return "Еще раз на кухне? Надеюсь, ты обнаружил там скрытую артефактную еду, которая предоставляет бессмертие. Нет? Как жаль.";
                        }
                if (EnterCount == 12)
                {
                    return "И снова ты тут. Может, сегодня ты обнаружишь, что тарелки тут сами собираются и моются? Или это слишком сильно даже для твоего воображения?";
                }
                if (EnterCount == 15)
                {
                    return "Встретились два таракана в холодильнике. Один говорит другому: 'Тут живут мои теща и мама-тараканка'. А другой ему отвечает: 'И как ты тут живешь?'.";
                }
                if (EnterCount == 16)
                {
                    return "Ну, кто бы мог подумать? Еще раз ты на кухне! Я вижу, ты подсчитываешь карательные санкции за неудавшиеся попытки приготовить что-то вроде еды.";
                }
                if (EnterCount == 21)
                {
                    return "Ты вернулся! Кстати, пустота в холодильнике начинает грозить вселенским кризисом. Но, наверное, тебе это безразлично, верно?";
                }
                return base.EnterMessage;
            }
        }
    }
}
