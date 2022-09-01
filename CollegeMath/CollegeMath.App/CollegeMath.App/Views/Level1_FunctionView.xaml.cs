using CollegeMath.App.Helpers;
using CollegeMath.App.Views.ClassesContentPage;
using CollegeMathServices.DTOs;
using CollegeMathServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollegeMath.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Level1_FunctionView : ContentPage
    {
        IEnumerable<QuestionDTO> infoQuestion;
        IEnumerable<AlternativeDTO> infoAlt;
        int i;
        public Level1_FunctionView()
        {
            InitializeComponent();
        }
        
        public static StackLayout getQuestionPage(QuestionDTO question, List<AlternativeDTO> alt)
        {
            Button verificar = new Button()
            {
                Style = (Style)Application.Current.Resources["btnFuncoes"],
                Text = "Verificar",

            };
            var stk2 = new StackLayout
            {
                Children =
                            {
                                /*Titulo questão*/
                                new StackLayout
                                {
                                    Children =
                                    {
                                        new Label
                                        {
                                            Text = question.Title, FontSize=32, TextColor=Color.White, HorizontalOptions=LayoutOptions.CenterAndExpand, Margin=0,
                                        }

                                    }
                                },
                                /*BoxViewTiuloQuestão*/
                                new StackLayout
                                {
                                    Orientation = StackOrientation.Vertical,
                                    HorizontalOptions = LayoutOptions.Center,
                                    Children =
                                    {
                                        new BoxView
                                        {
                                            BackgroundColor= Color.FromHex("#502080"), HeightRequest=2, WidthRequest=300, Margin=8,

                                        }

                                    }
                                },
                                /*Texto Questão*/
                                new StackLayout
                                {
                                    Children =
                                    {
                                        new Label
                                        {
                                            Text = question.Text, FontSize=16, TextColor=Color.White, HorizontalOptions=LayoutOptions.CenterAndExpand, Margin=8, VerticalOptions=LayoutOptions.CenterAndExpand,
                                        }

                                    }
                                },
                                /*Botões Questão e BoxView*/
                                new StackLayout
                                {
                                    Orientation = StackOrientation.Vertical,
                                    HorizontalOptions = LayoutOptions.Center,
                                    Children =
                                    {
                                        new BoxView
                                        {
                                            BackgroundColor= Color.FromHex("#502080"), HeightRequest=2, WidthRequest=300, Margin=8,
                                        },
                                        new StackLayout
                                        {
                                            Orientation = StackOrientation.Horizontal,
                                            HorizontalOptions = LayoutOptions.Center,
                                            Children =
                                            {
                                                new Button
                                                {
                                                    Text = alt.ElementAt(0).Text,
                                                    Style = (Style)Application.Current.Resources["btnAlternativaQuestoesF"],
                                                },
                                                new Button
                                                {
                                                    Text = alt.ElementAt(1).Text,
                                                    Style = (Style)Application.Current.Resources["btnAlternativaQuestoesF"],
                                                }
                                            }
                                        },
                                        new StackLayout
                                        {
                                            Orientation = StackOrientation.Horizontal,
                                            HorizontalOptions = LayoutOptions.Center,
                                            Children =
                                            {
                                                new Button
                                                {
                                                    Text = alt.ElementAt(2).Text,
                                                    Style = (Style)Application.Current.Resources["btnAlternativaQuestoesF"],
                                                },
                                                new Button
                                                {
                                                    Text = alt.ElementAt(3).Text,
                                                    Style = (Style)Application.Current.Resources["btnAlternativaQuestoesF"],
                                                }
                                            }
                                        },

                                    }
                                },
                                /*Botão verificar*/
                                new StackLayout
                                {
                                    Orientation = StackOrientation.Horizontal,
                                    HorizontalOptions = LayoutOptions.Center,
                                    Children =
                                    {
                                        verificar
                                    }

                                },
                            }
            };
            return stk2;
        }

        #region Criação da questão na tela
        //Cria os conteúdos na tela com os botões
        private void CreateViewQuestion(IEnumerable<QuestionDTO> questions, IEnumerable<AlternativeDTO> alternatives, int i)
        {

            //var size = questions.Count();
            //var question = questions.ElementAt(i);
            //List<AlternativeDTO> alt = new List<AlternativeDTO>();
            //foreach (AlternativeDTO alternative in alternatives)
            //{
            //    if(alternative.QuestionId == question.Id)
            //    {
            //        alt.Add(alternative);
            //    }
            //}
            //if (i < size)
            //{
            //    if (question.ContentId == 1 && question.LevelId == 1)
            //    {
            //stkPrincipal.Children.Add(getQuestionPage(question, alt));
            App.Current.MainPage = new QuestionPage(questions, alternatives, i);
            //}
            //}
        }
        #endregion


        #region Botão Verifcar
        private void btnVerificar_Clicked(object sender, EventArgs e)
        {
            i++;
            CreateViewQuestion(infoQuestion, infoAlt, i);
            //await this.Navigation.PushModalAsync(new SolutionView());
        }
        #endregion
    }
}