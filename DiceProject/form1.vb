Public Class Form1

    Private bFirstGame As Boolean
    Private iStartingMoney As Integer
    Private WithEvents myDice As New Dice()

    Private Sub myDice_CheckTheMoney(ByVal sender As System.Object,
                               ByVal e As String) Handles myDice.CheckMyMoney
        lblIssue.Text = e
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bFirstGame = True

        lblIssue.Text = ""
        tbInitial.Text = "1000"
        tbInitial.ReadOnly = False
        tbBet.Text = "200"

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim iBet As Integer
        Dim bSmaller As Boolean

        lblIssue.Text = ""

        Try
            If bFirstGame Then
                iStartingMoney = Convert.ToDouble(tbInitial.Text)
                lblStartingMoney.Text = iStartingMoney.ToString()
                myDice.TotalMoney = iStartingMoney
            End If

            tbInitial.ReadOnly = True
            bFirstGame = False
            iBet = Convert.ToDouble(tbBet.Text)

            myDice.BetMoney = Convert.ToDouble(tbBet.Text)
            bSmaller = rbSmaller.Checked
            myDice = New Dice(myDice.TotalMoney, myDice.BetMoney, bSmaller)

            Call myDice.RollTheDice()

            tbInitial.Text = myDice.TotalMoney.ToString
            lblResult.Text = myDice.Result.ToString
            lblStartingMoney.Text = iStartingMoney.ToString
            lblCurrentMoney.Text = myDice.TotalMoney.ToString

        Catch ex As Exception
            MessageBox.Show("Error" & vbCrLf & " Probably you have not given any input" & vbCrLf & "Or you are out of money...")
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        bFirstGame = True

        tbInitial.Text = "1000"
        tbInitial.ReadOnly = False

        tbBet.Text = "200"
        lblIssue.Text = ""
        lblStartingMoney.Text = "Thank you"
        lblResult.Text = "for"
        lblCurrentMoney.Text = "playing!"

    End Sub

End Class
