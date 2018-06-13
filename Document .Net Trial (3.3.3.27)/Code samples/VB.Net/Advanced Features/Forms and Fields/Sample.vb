Imports SautinSoft.Document

Module ExampleVB

    Sub Main()
        FormsAndFields()
    End Sub
    Sub FormsAndFields()
        Dim dc As DocumentCore = DocumentCore.Load("..\..\..\..\..\Testing Files\fields-template.docx")

        ' Fill document header.
        dc.MailMerge.Execute(New With {
            Key .CompanyName = "Picture gallery of USA",
            Key .Address = "720 Sacramento St, San Francisco, CA 94108",
            Key .PrintDate = Date.Now.ToLongDateString(),
            Key .PaintingNumber = "123/5-68",
            Key .ContactName = "Mr. Bean"
        })

        ' Options for writing a date.
        dc.Sections.Add(New Section(dc, New Paragraph(dc, New Run(dc, "Date: "), New Field(dc, FieldType.Date), New SpecialCharacter(dc, SpecialCharacterType.LineBreak), New Run(dc, "Date (formatted): "), New Field(dc, FieldType.Date, "\@ ""dddd, MMMM dd, yyyy""  \* MERGEFORMAT"), New SpecialCharacter(dc, SpecialCharacterType.LineBreak), New Run(dc, "Date & Time (formatted): "), New Field(dc, FieldType.Date, " \@ ""M/d/yyyy h:mm:ss am/pm""  \* MERGEFORMAT"))))
        ' { DATE }
        ' { DATE \@ "dddd, MMMM dd, yyyy"  \* MERGEFORMAT }
        ' { DATE  \@ "M/d/yyyy h:mm:ss am/pm"  \* MERGEFORMAT }

        Dim placeHolder As New String(ChrW(&H2002), 50)

        ' Create form fields.

        Dim fFullName As New Field(dc, FieldType.FormText, Nothing, placeHolder)
        fFullName.FormData.Name = "FullName"
        fFullName.FormData.Enabled = True


        Dim fBirthData As New Field(dc, FieldType.FormText, Nothing, placeHolder)
        fBirthData.FormData.Name = "BirthDate"

        Dim fGender As New Field(dc, FieldType.FormDropDown)
        fGender.FormData.Name = "Gender"

        Dim fMarried As New Field(dc, FieldType.FormCheckBox)
        fMarried.FormData.Name = "Married"
        fMarried.FormData.Enabled = True


        Dim fPhone As New Field(dc, FieldType.FormText, Nothing, placeHolder)
        fPhone.FormData.Name = "Phone"

        dc.Sections.Add(New Section(dc, New Paragraph(dc, New Run(dc, "Full name: "), fFullName), New Paragraph(dc, New Run(dc, "Birth date: "), fBirthData), New Paragraph(dc, New Run(dc, "Gender: "), fGender), New Paragraph(dc, New Run(dc, "Married: "), fMarried), New Paragraph(dc, New Run(dc, "Phone: "), fPhone)))


        ' Customize form fields.
        Dim formFieldsData = dc.Content.FormFieldsData

        Dim fullNameFieldData = CType(formFieldsData("FullName"), FormTextData)
        fullNameFieldData.MaximumLength = 50
        'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
        'ORIGINAL LINE: fullNameFieldData.StatusText = fullNameFieldData.HelpText = "Enter your name and surname (trimmed to 50 characters).";
        fullNameFieldData.HelpText = "Enter your name and surname (trimmed to 50 characters)."
        fullNameFieldData.StatusText = fullNameFieldData.HelpText
        fullNameFieldData.Field.ResultInlines.Content.Replace("Mister Bean")

        Dim birthdateFieldData = CType(formFieldsData("BirthDate"), FormTextData)
        birthdateFieldData.TextType = FormTextType.Date
        birthdateFieldData.DefaultValue = "1990-01-01"
        birthdateFieldData.ValueFormat = "yyyy-MM-dd"
        'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
        'ORIGINAL LINE: birthdateFieldData.StatusText = birthdateFieldData.HelpText = "Enter your date of birth.";
        birthdateFieldData.HelpText = "Enter your date of birth."
        birthdateFieldData.StatusText = birthdateFieldData.HelpText
        birthdateFieldData.Field.ResultInlines.Content.Replace("1990-01-01")

        Dim genderFieldData = CType(formFieldsData("Gender"), FormDropDownData)
        genderFieldData.Items.Add("Select sex")
        genderFieldData.Items.Add("Male")
        genderFieldData.Items.Add("Female")
        genderFieldData.Items.Add("I don't know")
        'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
        'ORIGINAL LINE: genderFieldData.StatusText = genderFieldData.HelpText = "Select your gender.";
        genderFieldData.HelpText = "Select your gender."
        genderFieldData.StatusText = genderFieldData.HelpText
        genderFieldData.SelectedItemIndex = 0

        Dim marriedFieldData = CType(formFieldsData("Married"), FormCheckBoxData)
        'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
        'ORIGINAL LINE: marriedFieldData.StatusText = marriedFieldData.HelpText = "Mark as checked if you are married.";
        marriedFieldData.HelpText = "Mark as checked if you are married."
        marriedFieldData.StatusText = marriedFieldData.HelpText
        marriedFieldData.DefaultValue = True
        marriedFieldData.Value = True

        Dim salaryFieldData = CType(formFieldsData("Phone"), FormTextData)
        salaryFieldData.TextType = FormTextType.Number
        salaryFieldData.DefaultValue = "555 13-12"
        salaryFieldData.ValueFormat = "(###) ###-####"
        'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
        'ORIGINAL LINE: salaryFieldData.StatusText = salaryFieldData.HelpText = "Enter your phone number.";
        salaryFieldData.HelpText = "Enter your phone number."
        salaryFieldData.StatusText = salaryFieldData.HelpText
        salaryFieldData.Field.ResultInlines.Content.Replace("+1 (800) 111 2233")

        dc.Save("fields-template.pdf", New PdfSaveOptions() With {.PreserveFormFields = True})

        ' Open the result for demonstation purposes.
        System.Diagnostics.Process.Start(New System.Diagnostics.ProcessStartInfo("fields-template.pdf") With {.UseShellExecute = True})
    End Sub
End Module