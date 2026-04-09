using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Knowledge_Matrix
{
    public partial class FriendHelp : Form
    {
        public FriendHelp()
        {
            InitializeComponent();
        }

        
        private void buttonYourReplic_Click(object sender, EventArgs e)
        {
            string friendsAnswer = Form_KnowledgeMatrix.GetFriendHelp();
            if (button_YourReplic.Text == "Привет")
            {
                textBox_FriendsReplic.Text = "Привет";
                button_YourReplic.Text = "Мне нужна помощь";
            }
            else
            {
                if (button_YourReplic.Text == "Мне нужна помощь")
                {
                    textBox_FriendsReplic.Text = "Конечно помогу! Что случилось?";
                    button_YourReplic.Text = "*Прочитать другу вопрос*";
                }
                else
                {
                    if (button_YourReplic.Text == "*Прочитать другу вопрос*")
                    {
                        textBox_FriendsReplic.Text = $"Я думаю ответ - {friendsAnswer}.";
                        button_YourReplic.Text = "Спасибо";
                    }
                    else
                    {
                        if (button_YourReplic.Text == "Спасибо")
                        {
                            textBox_FriendsReplic.Text = $"Всегда готов помочь!";
                            button_YourReplic.Text = "*Завершить звонок*";
                        }
                        else
                        {
                            if (button_YourReplic.Text == "*Завершить звонок*")
                            {
                                textBox_FriendsReplic.Text = "";
                                button_YourReplic.Text = "";
                                this.Close();
                            }
                        }

                    }

                }

            }

        }
    }
}
