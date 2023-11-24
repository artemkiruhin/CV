import telebot
from telebot import types
from mysql.connector import connect, Error
import bot_settings

users = bot_settings.users
buttons_stack = []
bot = telebot.TeleBot(bot_settings.token)

@bot.message_handler(commands=['start'])
def url(message):
    if IsMyUserId(message.from_user.id):
        murkup = MainChatMurkup()
        bot.send_message(message.from_user.id, "👋 Привет! Я твой бот-помошник!", reply_markup=murkup)
    else:
        ResposeToNotMyId(message)

@bot.message_handler(func=lambda m: m.text == 'Новые сообщения')
def check(message):
    if IsMyUserId(message.from_user.id):
        markup = types.ReplyKeyboardMarkup(resize_keyboard=True)
        back_button = types.KeyboardButton('Вернуться')
        markup.add(back_button)

        buttons_stack.append(markup)

        feedbacks = GetNewFeedbacks()

        bot.send_message(message.chat.id, feedbacks, reply_markup=markup)
    else:
        ResposeToNotMyId(message)

@bot.message_handler(func=lambda m: m.text == 'Вернуться')
def back(message):
    murkup = MainChatMurkup()
    bot.send_message(message.chat.id, "Вернулись", reply_markup=murkup)

def IsMyUserId(id):
    for u in users:
        if id == u:
            return True
    return False

def ResposeToNotMyId(message):
    murkup = types.ReplyKeyboardMarkup(resize_keyboard=True)
    bot.send_message(message.chat.id, 'Я вам ничего не отвечу, всего доброго!', reply_markup=murkup)

def GetNewFeedbacks():
    try:
        with connect(
                host="localhost",
                user='root',
                password='root',
                database='cv_database') as connection:
            print(connection)
            query = 'SELECT * FROM Feedbacks'
            cursor = connection.cursor()
            cursor.execute(query)  # Выполнение запроса к базе данных
            feedbacks = cursor.fetchall()
            message = ''
            for f in feedbacks:
                message += f'ID: {f[0]}\nОтправитель: {f[1]}\nСообщение: {f[3]}\n\n\n'
            return message

    except Error as e:
        print(e)

def MainChatMurkup():
    murkup = types.ReplyKeyboardMarkup(resize_keyboard=True)
    checkNewFeedbackButton = types.KeyboardButton('Новые сообщения')
    murkup.add(checkNewFeedbackButton)
    return murkup

bot.polling(none_stop=True, interval=0) #обязательная для работы бота часть

