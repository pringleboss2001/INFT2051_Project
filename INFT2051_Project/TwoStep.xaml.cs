namespace INFT2051_Project;

public partial class TwoStep : ContentPage
{
    public int a = 0;
    public int b = 0;
    public int c = 0;
    public int AddSub = 0;
    public int MulDiv = 0;

    public TwoStep()
	{
		InitializeComponent();
    }

    public async void OnButtonClicked(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
         
            if (btn == NextQuestion)
            { 
                NextQuestion.Text = "Next Question";
                a = getIntegerA();
                b = getIntegerB();
                c = getIntegerC();
                AddSub = getOperatorAddSub();
                MulDiv = getOperatorMulDiv();

                if (MulDiv == 1)
                {
                    if (AddSub == 1)
                    {
                        //if MulDiv and AddSub == 1, the we have an equation of the form ax + b = c
                        Question_Label.Text = $"{a}x + {b} = {c}";
                    }
                    else
                    {
                        //Equation of the form ax - b = c
                        Question_Label.Text = $"{a}x - {b} = {c}";
                    }
                }

                else if (MulDiv == 2)
                {
                    if (AddSub == 1)
                    {
                        //Equation of the form x/a + b = x
                        Question_Label.Text = $"x/{a} + {b} = {c}";
                    }
                    else
                    {
                        //equation of the form x/a - b = c
                        Question_Label.Text = $"x/{a} - {b} = {c}";
                    }
                }
            }   

            if (btn == ShowAnswer)
            {
                getAnswer(a, b, c, MulDiv, AddSub);
            }

            if (btn == TwoStepBack)
                await Navigation.PushAsync(new MainPage());

    }

    public int getIntegerA()
    {
        Random numberGenerator = new Random();
        int a = numberGenerator.Next(1, 11);
        return a;
    }

    public int getIntegerB()
    {
        Random numberGenerator = new Random();
        int b = numberGenerator.Next(1, 11);
        return b;
    }

    public int getIntegerC()
    {
        Random numberGenerator = new Random();
        int c = numberGenerator.Next(1, 11);
        return c;
    }

    public int getOperatorAddSub()
    {
        Random numberGenerator = new Random();
        int AddSub = numberGenerator.Next(1, 3);
        return AddSub;
    }

    public int getOperatorMulDiv()
    {
        Random numberGenerator = new Random();
        int MulDiv = numberGenerator.Next(1, 3);
        return MulDiv;
    }

    public void getAnswer(int a, int b, int c, int MulDiv, int AddSub)
    {
        int TS_Answer = 0;  //initialising the answer
        int TS_Whole_Check_Add = (c - b) % a;   //checking if the solution is a whole number
        int TS_Whole_Check_Sub = (c + b) % a;   //checking solution is a whole number

        /*
         *If AddSub == 1, the operator is addition
         *If AddSub == 2, the operator is subtraction
         *If MulDiv == 1, the operator is multiplication   
         *If MulDiv == 2, the operator is division
        */

        if (MulDiv == 1 && AddSub == 1)
        {
            //if MulDiv and AddSub == 1, the we have an equation of the form ax + b = c
            TS_Answer = (c - b) / a;
            if (TS_Whole_Check_Add == 0)
                Answer_Label.Text = TS_Answer.ToString();
            else
                Answer_Label.Text = $"{c - b} / {a}";
        }

        else if (MulDiv == 1 && AddSub == 2)
        {
                //Equation of the form ax - b = c
                TS_Answer = ((c + b) / a);
                if (TS_Whole_Check_Sub == 0)
                    Answer_Label.Text = TS_Answer.ToString();
                else
                    Answer_Label.Text = $"{c + b} / {a}";
        }

        else if (MulDiv == 2 && AddSub == 1)
        {
                //Equation of the form x/a + b = c
                int d = c - b;
                TS_Answer = (d * a);
                Answer_Label.Text = TS_Answer.ToString();
        }
        else if (MulDiv == 2 && AddSub == 2)
        {
                //equation of the form x/a - b = c
                TS_Answer = ((c + b) * a);
                Answer_Label.Text = TS_Answer.ToString();
        }
             
    }
}
                
   

            
        