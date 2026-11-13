using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Utility to export DataGridView data or transaction records to CSV for enterprise reporting.
    /// </summary>
    public static class ReportExporter
    {
        public static bool ExportToCsv(DataGridView dgv, string defaultFileName)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("There is no data available to export.", "Export Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV (Comma Delimited) (*.csv)|*.csv|All Files (*.*)|*.*";
                sfd.FileName = defaultFileName;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();

                        // Header row
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            if (dgv.Columns[i].Visible)
                            {
                                sb.Append(EscapeCsv(dgv.Columns[i].HeaderText));
                                if (i < dgv.Columns.Count - 1) sb.Append(",");
                            }
                        }
                        sb.AppendLine();

                        // Rows
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                for (int i = 0; i < dgv.Columns.Count; i++)
                                {
                                    if (dgv.Columns[i].Visible)
                                    {
                                        object val = row.Cells[i].Value;
                                        sb.Append(EscapeCsv(val?.ToString() ?? ""));
                                        if (i < dgv.Columns.Count - 1) sb.Append(",");
                                    }
                                }
                                sb.AppendLine();
                            }
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Report exported successfully to:\n" + sfd.FileName, "Export Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to export report: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return false;
        }

        private static string EscapeCsv(string text)
        {
            if (string.IsNullOrEmpty(text)) return "\"\"";
            if (text.Contains(",") || text.Contains("\"") || text.Contains("\n") || text.Contains("\r"))
            {
                return "\"" + text.Replace("\"", "\"\"") + "\"";
            }
            return "\"" + text + "\"";
        }
    }
}

