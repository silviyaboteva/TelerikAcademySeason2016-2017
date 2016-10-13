<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
    <html>
      <head>
        <title>Students</title>
        <style>
          body
          {
          font-family: Georgia, Serif;
          }
          h1
          {
          margin:10px;
          text-align: center;
          padding:10px;
          text-shadow: 1px 2px;
          }
          .student-container
          {
          margin:10px;
          border: 1px solid black;
          border-radius: 5px;
          background-color: lightgreen;
          font-size:20px;
          padding:10px;
          }

        </style>
      </head>
      <body>
        <h1>Students List</h1>
        <xsl:for-each select="students/student">
          <div class="student-container">
            Name: <xsl:value-of select="name"/>
            <div>
              Faculty Number: <xsl:value-of select="facultynumber"/>
            </div>
            <div class="exam-title">Taken exams:</div>
            <xsl:for-each select="exams/exam">
              <div class="exam-container">
                <xsl:value-of select="position()"/>. <xsl:value-of select="name"/> - Score: <xsl:value-of select="score"/> (Tutor: <xsl:value-of select="tutor"/>)
              </div>
            </xsl:for-each>
          </div>
        </xsl:for-each>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
