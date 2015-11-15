Public Class Dice

    Private p_iTotalMoney As Integer
    Private p_iBetMoney As Integer
    Private p_bHighResult As Boolean
    Private p_sResult As String

    Public Event CheckMyMoney(ByVal sender As Object, ByVal e As String)

    Public Sub New()
        p_iTotalMoney = 0
        p_iBetMoney = 0
        p_bHighResult = False
    End Sub

    Public Sub New(ByVal i_total_money As Integer, _
                   ByVal i_bet_money As Integer, _
                   ByVal bHighResult As Boolean)

        TotalMoney = i_total_money
        BetMoney = i_bet_money
        p_bHighResult = bHighResult

    End Sub

    Public ReadOnly Property Result As String
        Get
            Result = p_sResult
        End Get
    End Property

    Public Property BetMoney() As Integer
        Get
            Return Me.p_iBetMoney
        End Get

        Set(value As Integer)
            p_iBetMoney = value
        End Set
    End Property

    Public Property TotalMoney() As Integer
        Get
            Return p_iTotalMoney
        End Get

        Set(value As Integer)
            p_iTotalMoney = value
        End Set

    End Property

    Public Property HighResult() As Boolean
        Get
            Return p_bHighResult
        End Get
        Set(value As Boolean)
            p_bHighResult = value
        End Set
    End Property

    Private Function GetResult() As Integer
        Dim rnd As New Random()
        Return rnd.Next(1, 6)
    End Function

    Public Sub CheckTheMoney()

        If Me.BetMoney = Me.TotalMoney Then
            RaiseEvent CheckMyMoney(Me, "All in! Was it worthy?")
        ElseIf 3 * Me.BetMoney > Me.TotalMoney Then
            RaiseEvent CheckMyMoney(Me, "You are playing with a lot of money!")
        ElseIf 10 * Me.BetMoney < Me.TotalMoney Then
            RaiseEvent CheckMyMoney(Me, "I know you can bet more...")
        End If

    End Sub

    Public Sub RollTheDice()
        Dim iResult As Integer


        iResult = Me.GetResult()
        CheckTheMoney()

        If (iResult > 3 And p_bHighResult) Or (iResult < 4 And Not p_bHighResult) Then
            Me.TotalMoney += Me.BetMoney * 0.95
            p_sResult = "You win and you pay a winning fee of 5 %"
        Else
            'lose
            Me.TotalMoney -= Me.BetMoney
            p_sResult = "You lose"
        End If
    End Sub



End Class
