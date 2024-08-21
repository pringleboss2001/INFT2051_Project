using Mehroz;
namespace INFT2051_Project;

public partial class FractionsPage : ContentPage
{
    int percentageAnswer = 0;
    int decimalAnswer = 0;
    int PercDec = 0;
	public FractionsPage()
	{
		InitializeComponent();
	}

    public async void OnButtonClicked(object sender, EventArgs e)
    {

        Button btn = (Button)sender;    //This line reads which button was pressed. Allows for unique instances of button presses.
        if (btn == Back)
            await Navigation.PushAsync(new MainPage());
        else if (btn == NextQuestion)
        {
            //display question function
            Random numberGenerator = new Random();
            decimalAnswer = numberGenerator.Next(1, 100);
            percentageAnswer = numberGenerator.Next(1, 100);
            PercDec = numberGenerator.Next(1, 3);
            createQuestion(percentageAnswer, decimalAnswer, PercDec);
        }
        else if (btn == SubmitAnswer)
        {
            //Display solution + answer
            string answerInput = AnswerInput.Text;
            checkAnswer(percentageAnswer, decimalAnswer, PercDec, answerInput);
        }
        else if (btn == ShowWorking)
        {
            WorkingGrid.IsVisible = true;
            showWorking(percentageAnswer, decimalAnswer, PercDec);
        }
    }

    public void createQuestion(int percentageAnswer, int decimalAnswer, int PercDec)
    {
        if (PercDec == 1)
        {
            QuestionLabel.Text = $" {percentageAnswer}% to a fraction.";
        }
        else
        {
            decimal dec = Convert.ToDecimal(decimalAnswer) / 100;
            QuestionLabel.Text = $" {dec} to a fraction.";
        }
    }

    public void showWorking(int percentageAnswer, int decimalAnswer, int PercDec)
    {
        decimal dec = Convert.ToDecimal(decimalAnswer) / 100;
        if (PercDec == 1)
        {
            Fraction frac = new Fraction(percentageAnswer, 100);
            Working1.Text = $"{percentageAnswer}% = {percentageAnswer}/100";
            Working2.Text = $"If possible, simplify. {percentageAnswer}/100 = {frac}";
            Working3.Text = $"{percentageAnswer}% = {frac}";
        }
        else
        {
            Fraction frac = new Fraction(decimalAnswer, 100);
            Working1.Text = $"{dec} = {decimalAnswer}/100";
            Working2.Text = $"If possible, simplify. {decimalAnswer}/100 = {frac}";
            Working3.Text = $"{dec} = {frac}";
        }
    }

    public void checkAnswer(int percentageAnswer, int decimalAnswer, int PercDec, string answerInput)
    {
        if (PercDec == 1)
        {
            Fraction fractionFromPerc = new Fraction(percentageAnswer, 100);
            if (answerInput == fractionFromPerc.ToString())
            { 
                AnswerLabel.Text = "Correct";
            }
            else
            {
                AnswerLabel.Text = "Wrong";
            }
        }
        else
        {
            Fraction fractionFromDec = new Fraction(decimalAnswer,100);
            if (answerInput == fractionFromDec.ToString())
            {
                AnswerLabel.Text = "Correct";
            }
            else
            {
                AnswerLabel.Text = "Wrong";
            }
        }
    }
}