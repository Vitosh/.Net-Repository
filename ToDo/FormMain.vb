Public Class FormMain
  Private objListBox As CToDoList
  Private p_counter As Long

  Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    objListBox = New CToDoList(lv, "#", "Task", "Status")
  End Sub
  
  Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
    objListBox.Addition(tb_task.Text, cb_status.Checked)
  End Sub

  Private Sub btn_remove_Click(sender As Object, e As EventArgs) Handles btn_remove.Click
    objListBox.RemoveSelected()
  End Sub

  Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
    objListBox.Fix(tb_task.Text, cb_status.Checked)
    p_counter += 1
    lbl_update.Text = "Updated " & p_counter
  End Sub

  Private Sub lv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv.SelectedIndexChanged
    If objListBox.check_selection Then Exit Sub
    cb_status.Checked = objListBox.get_status
    tb_task.Text = objListBox.get_task
    lbl_row_to_edit.Text = objListBox.get_number
  End Sub
End Class
