using System;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Drawing;
using System.IO;


public class MainForm : Form
{
	private TextBox inputText;
	private TextBox resuldText;
	private TextBox keyText;
	private Label result;
	private Label input;
	private Label keyLabel;
	private Button Do;
	private Button Open;
	private Button Save;


	public MainForm()
	{
		
		this.Size = new Size(600,410);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		this.Text = "Easy Incrypter";


		inputText = new TextBox();
		resuldText = new TextBox();
		keyText = new TextBox();
		result = new Label();
		input = new Label();
		keyLabel = new Label();
		Do = new Button();
		Open = new Button();
		Save = new Button();

		inputText.Multiline = true;
		resuldText.Multiline = true;
		keyText.Multiline = true;

		inputText.Size = new Size(550,120);
		resuldText.Size = new Size(550,120);
		keyText.Size = new Size(550,25);

		inputText.Location = new Point(0,20);
		resuldText.Location = new Point(0, 160);
		keyText.Location = new Point(0,320);

		inputText.ScrollBars = ScrollBars.Vertical;
		resuldText.ScrollBars = ScrollBars.Vertical;

		Do.Location = new Point (250,290);
		Open.Location = new Point (350,290);
		Save.Location = new Point (450,290);

		Do.Text = "Do";
		Open.Text = "Open";
		Save.Text = "Save";

		result.Location = new Point (0,140);
		input.Location = new Point (0,0);
		keyLabel.Location = new Point (0,300);

		result.Text = "Result";
		input.Text= "Input";
		keyLabel.Text = "Key";

		Save.Click += Save_Click;
		Open.Click += Open_Click;
		Do.Click += Do_Click;

		Controls.Add(inputText);
		Controls.Add(resuldText);
		Controls.Add(keyText);
		Controls.Add(result);
		Controls.Add(input);
		Controls.Add(keyLabel);
		Controls.Add(Do);
		Controls.Add(Open);
		Controls.Add(Save);

	}


	private void Save_Click (object sender, EventArgs e)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog ();

		DialogResult result = saveFileDialog.ShowDialog();

		if(result != DialogResult.OK)return;
		File.WriteAllLines(saveFileDialog.FileName, resuldText.Lines);
	}

	private void Do_Click (object sender, EventArgs e)
	{
		if(keyText.Text.Length == 0)
		{
			MessageBox.Show("вы не ввели ключ шифрования");
			return;
		}
		int key = 0;
		if (int.TryParse (keyText.Text, out key) == false) {
			if (keyText.Text.Length > 10) {
				MessageBox.Show ("ключ не должен быть больше 10 знаков");
				return;
			}
			MessageBox.Show ("ВВедите число");
			return;
		} 
		else
		{
			int i = Convert.ToInt32 (keyText.Text);
			resuldText.Text = Encrypter.ApplyXOR(inputText.Text, i);
		}
	}

	private void Open_Click (object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog ();
		openFileDialog.Filter = "txt files (*.txt) | *.txt";
		DialogResult result = openFileDialog.ShowDialog ();

		if(result != DialogResult.OK) return;
		inputText.Lines = File.ReadAllLines(openFileDialog.FileName);
	}


		




}


