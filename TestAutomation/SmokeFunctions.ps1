# Global variables...
$emailFrom = "donotreply@meridianksi.com"
$emailTo = "epostlethwait@meridianksi.com","jdowns@meridianksi.com","ksearch@meridianksi.com","arajagopalan@meridianksi.com","dkutty@meridianksi.com","subbu@meridianksi.com","safzal@meridianksi.com","sbanerjee@meridianksi.com","ykamal@meridianksi.com"
$emailToTestGroup = "safzal@meridianks.com"
$smtpServer = "mailrelay"
$newline = "<br>"

Function ParseSmokeTest( $ReportsDir )
{
    # Find the last modified XML file and find the one with the latest modified date...
    $FileList = Join-Path -path $ReportsDir -childpath "*.xml"
    $FileToParse = Get-ChildItem $FileList | where { -not $_.PsIsContainer } | sort LastWriteTime -descending | select -first 1

    # Read XML file into memory...
    [xml]$xd = Get-Content $FileToParse.FullName

    # Check result to see if it TRUE and return value...
    if( $xd."test-results"."test-suite".success.CompareTo( "True" ) -eq 0 ) { exit 0 } else { exit 1 }
}

#
#############################################
#

Function CheckEnvironmentVariables( $RootDir )
{
    # Config files and keys to check...  Also defaults for the $KeyList are in $ResultsList (in order)...
    $FileList = @( 'CServer\SiteConfiguration\BaseSite.config', 'CServer\SiteConfiguration\EnvironmentSite.config' )
    $KeyList = @( 'ActiveDirectoryOn', 'PersonifyIntegrationOn', 'CGI_INTEGRATION' )
    $ResultList = @( 'false', 'false', 'Off' )

    foreach( $entry in $FileList ) 
    {
        $file = Join-Path -path $RootDir -childpath $entry
        [xml]$xd = Get-Content $file
        foreach( $value in $xd.appSettings.add )
        {
            # $value.key has the entries that we are looking for in $KeyList...
            # $value.value has the entry of the $KeyList entry...
            foreach( $entry in $KeyList )
            {
                if( $value.key -match $entry )
                {
                    # Found match, update the corresponding value in $ResultList...
                    $index = [array]::IndexOf( $KeyList, $value.key )
                    $ResultList[ $index ] = $value.value
                }
            }
        }
    }

    # Check values in ResultList...  
    # If everything is 'false' or 'Off', return a "1" (to continue the smoke test..)
    # If something is 'true' or 'On', return a "0" (do not run the smoke test...)
    $bRunSmokeTest = $true
    $count = $ResultList.Count

    for( $i=0; $i -lt $count; $i++ )
    {
        if(( $ResultList[ $i ].CompareTo( "true" ) -eq 0 ) -or ( $ResultList[ $i ].CompareTo( "on" ) -eq 0 )) { $bRunSmokeTest = $false }
    }

    # Return the value...
    if( $bRunSmokeTest -eq $true ) { exit 1 } else { exit 0 }
}

#
#############################################
#

Function EmailResults( $envVar_LMSversion, $envVar_success, $ReportsDir )
{
    $FileList = Join-Path -path $ReportsDir -childpath "*.html"
    $envVar_attachment = Get-ChildItem $FileList | where { -not $_.PsIsContainer } | sort LastWriteTime -descending | select -first 1

    $tempdate = get-date

    # Generate subject line
    if( $envVar_success -eq 0 ) { $envVar_subject = "Smoke Test (" + $tempdate + ") -- PASSED!!" } else { $envVar_subject = "Smoke Test (" + $tempdate + ") -- FAILED!!" }

    # Form email body...
    $str_body = ""
    $str_body += "The latest smoke test of $envVar_LMSVersion on the DEV environment has finished.  The smoke test:" + $newline + $newline
    if( $envVar_success -eq 0 ) { $str_body += "<b><font size=12 color=GREEN>PASSED!!</font></b>" } else { $str_body += "<b><font size=12 color=RED>FAILED!!</font></b>" }
    $str_body += $newline + $newline + "Please see attachment for detailed information on the smoke test." + $newline + $newline + $newline

    # Put timestamp on the end of the email...
    $str_body += "<h5>Message generated on: " + $tempdate + ".</h5>"

    # Send the email...
    Send-MailMessage -smtpServer $smtpServer -to $emailTo -from $emailFrom -subject $envVar_subject -bodyashtml $str_body -attachments $envVar_attachment.FullName
}

#
#############################################
#

Function SkippedSmokeTest( $envVar_LMSversion )
{
    $envVar_subject = "Smoke Test not executed on " + $envVar_LMSversion + " DEV environment"

    # Form email body...
    $str_body = "The smoke test of $envVar_LMSVersion on the DEV environment was not executed due to an environment variable in the `"on`"/`"true`" position." + $newline + $newline + $newline

    # Put timestamp on the end of the email...
    $tempdate = get-date
    $str_body += "<h5>Message generated on: " + $tempdate + ".</h5>"

    # Send the email...
    Send-MailMessage -smtpServer $smtpServer -to $emailTo -from $emailFrom -subject $envVar_subject -bodyashtml $str_body
}

#
#############################################
#

Function DeployedToQA( $envVar_LMSversion )
{
    $envVar_subject = $envVar_LMSversion + " deployed to the QA environment"

    # Form email body...
    $str_body = "The latest build of $envVar_LMSVersion has been deployed to the QA environment." + $newline + $newline + $newline

    # Put timestamp on the end of the email...
    $tempdate = get-date
    $str_body += "<h5>Message generated on: " + $tempdate + ".</h5>"

    # Send the email...
    Send-MailMessage -smtpServer $smtpServer -to $emailTo -from $emailFrom -subject $envVar_subject -bodyashtml $str_body
}

#
#############################################
#

Function EmailTestGroup( $envVar_LMSversion, $envVar_success, $ReportsDir )
{
    $FileList = Join-Path -path $ReportsDir -childpath "*.html"
    $envVar_attachment = Get-ChildItem $FileList | where { -not $_.PsIsContainer } | sort LastWriteTime -descending | select -first 1

    $tempdate = get-date

    # Generate subject line
    if( $envVar_success -eq 0 ) { $envVar_subject = "Smoke Test (" + $tempdate + ") -- PASSED!!" } else { $envVar_subject = "Smoke Test (" + $tempdate + ") -- FAILED!!" }

    # Form email body...
    $str_body = ""
    $str_body += "The latest smoke test of $envVar_LMSVersion on the EXTERNAL environment has finished.  The smoke test:" + $newline + $newline
    if( $envVar_success -eq 0 ) { $str_body += "<b><font size=12 color=GREEN>PASSED!!</font></b>" } else { $str_body += "<b><font size=12 color=RED>FAILED!!</font></b>" }
    $str_body += $newline + $newline + "Please see attachment for detailed information on the smoke test." + $newline + $newline + $newline

    # Put timestamp on the end of the email...
    $str_body += "<h5>Message generated on: " + $tempdate + ".</h5>"

    # Send the email...
    Send-MailMessage -smtpServer $smtpServer -to $emailToTestGroup -from $emailFrom -subject $envVar_subject -bodyashtml $str_body -attachments $envVar_attachment.FullName
}
Function EmailTestGroup1( $envVar_LMSversion, $envVar_success, $ReportsDir )
{
    $FileList = Join-Path -path $ReportsDir -childpath "*.html"
    $envVar_attachment = Get-ChildItem $FileList | where { -not $_.PsIsContainer } | sort LastWriteTime -descending | select -first 1

    $tempdate = get-date

    # Generate subject line
    if( $envVar_success -eq 0 ) { $envVar_subject = "Career Development Test (" + $tempdate + ") -- PASSED!!" } else { $envVar_subject = "Career Development Test (" + $tempdate + ") -- FAILED!!" }

    # Form email body...
    $str_body = ""
    $str_body += "The Career Development test of $envVar_LMSVersion on the EXTERNAL environment has finished.  The Career Development test:" + $newline + $newline
    if( $envVar_success -eq 0 ) { $str_body += "<b><font size=12 color=GREEN>PASSED!!</font></b>" } else { $str_body += "<b><font size=12 color=RED>FAILED!!</font></b>" }
    $str_body += $newline + $newline + "Please see attachment for detailed information on the Career Development test." + $newline + $newline + $newline

    # Put timestamp on the end of the email...
    $str_body += "<h5>Message generated on: " + $tempdate + ".</h5>"

    # Send the email...
    Send-MailMessage -smtpServer $smtpServer -to $emailToTestGroup -from $emailFrom -subject $envVar_subject -bodyashtml $str_body -attachments $envVar_attachment.FullName
}
Function EmailTestGroup2( $envVar_LMSversion, $envVar_success, $ReportsDir )
{
    $FileList = Join-Path -path $ReportsDir -childpath "*.html"
    $envVar_attachment = Get-ChildItem $FileList | where { -not $_.PsIsContainer } | sort LastWriteTime -descending | select -first 1

    $tempdate = get-date

    # Generate subject line
    if( $envVar_success -eq 0 ) { $envVar_subject = "Career Path Test (" + $tempdate + ") -- PASSED!!" } else { $envVar_subject = "Career Path Test (" + $tempdate + ") -- FAILED!!" }

    # Form email body...
    $str_body = ""
    $str_body += "The Career Path test of $envVar_LMSVersion on the EXTERNAL environment has finished.  The Career Path test:" + $newline + $newline
    if( $envVar_success -eq 0 ) { $str_body += "<b><font size=12 color=GREEN>PASSED!!</font></b>" } else { $str_body += "<b><font size=12 color=RED>FAILED!!</font></b>" }
    $str_body += $newline + $newline + "Please see attachment for detailed information on the Career Path test." + $newline + $newline + $newline

    # Put timestamp on the end of the email...
    $str_body += "<h5>Message generated on: " + $tempdate + ".</h5>"

    # Send the email...
    Send-MailMessage -smtpServer $smtpServer -to $emailToTestGroup -from $emailFrom -subject $envVar_subject -bodyashtml $str_body -attachments $envVar_attachment.FullName
}
Function EmailTestGroup3( $envVar_LMSversion, $envVar_success, $ReportsDir )
{
    $FileList = Join-Path -path $ReportsDir -childpath "*.html"
    $envVar_attachment = Get-ChildItem $FileList | where { -not $_.PsIsContainer } | sort LastWriteTime -descending | select -first 1

    $tempdate = get-date

    # Generate subject line
    if( $envVar_success -eq 0 ) { $envVar_subject = "Recommendation Tag Test (" + $tempdate + ") -- PASSED!!" } else { $envVar_subject = "Recommendation Tag Test (" + $tempdate + ") -- FAILED!!" }

    # Form email body...
    $str_body = ""
    $str_body += "The Recommendation Tag test of $envVar_LMSVersion on the EXTERNAL environment has finished.  The Recommendation Tag test:" + $newline + $newline
    if( $envVar_success -eq 0 ) { $str_body += "<b><font size=12 color=GREEN>PASSED!!</font></b>" } else { $str_body += "<b><font size=12 color=RED>FAILED!!</font></b>" }
    $str_body += $newline + $newline + "Please see attachment for detailed information on the Recommendation Tag test." + $newline + $newline + $newline

    # Put timestamp on the end of the email...
    $str_body += "<h5>Message generated on: " + $tempdate + ".</h5>"

    # Send the email...
    Send-MailMessage -smtpServer $smtpServer -to $emailToTestGroup -from $emailFrom -subject $envVar_subject -bodyashtml $str_body -attachments $envVar_attachment.FullName
}
Function EmailTestGroup4( $envVar_LMSversion, $envVar_success, $ReportsDir )
{
    $FileList = Join-Path -path $ReportsDir -childpath "*.html"
    $envVar_attachment = Get-ChildItem $FileList | where { -not $_.PsIsContainer } | sort LastWriteTime -descending | select -first 1

    $tempdate = get-date

    # Generate subject line
    if( $envVar_success -eq 0 ) { $envVar_subject = "Section Management Test (" + $tempdate + ") -- PASSED!!" } else { $envVar_subject = "Section Management Test (" + $tempdate + ") -- FAILED!!" }

    # Form email body...
    $str_body = ""
    $str_body += "The Section Management test of $envVar_LMSVersion on the EXTERNAL environment has finished.  The Section Management test:" + $newline + $newline
    if( $envVar_success -eq 0 ) { $str_body += "<b><font size=12 color=GREEN>PASSED!!</font></b>" } else { $str_body += "<b><font size=12 color=RED>FAILED!!</font></b>" }
    $str_body += $newline + $newline + "Please see attachment for detailed information on the Section Management test." + $newline + $newline + $newline

    # Put timestamp on the end of the email...
    $str_body += "<h5>Message generated on: " + $tempdate + ".</h5>"

    # Send the email...
    Send-MailMessage -smtpServer $smtpServer -to $emailToTestGroup -from $emailFrom -subject $envVar_subject -bodyashtml $str_body -attachments $envVar_attachment.FullName
}
Function EmailTestGroup5( $envVar_LMSversion, $envVar_success, $ReportsDir )
{
    $FileList = Join-Path -path $ReportsDir -childpath "*.html"
    $envVar_attachment = Get-ChildItem $FileList | where { -not $_.PsIsContainer } | sort LastWriteTime -descending | select -first 1

    $tempdate = get-date

    # Generate subject line
    if( $envVar_success -eq 0 ) { $envVar_subject = "Certification by Credit Type Hours Test (" + $tempdate + ") -- PASSED!!" } else { $envVar_subject = "Certification by Credit Type Hours Test (" + $tempdate + ") -- FAILED!!" }

    # Form email body...
    $str_body = ""
    $str_body += "The Certification by Credit Type Hours test of $envVar_LMSVersion on the EXTERNAL environment has finished.  The Certification by Credit Type Hours test:" + $newline + $newline
    if( $envVar_success -eq 0 ) { $str_body += "<b><font size=12 color=GREEN>PASSED!!</font></b>" } else { $str_body += "<b><font size=12 color=RED>FAILED!!</font></b>" }
    $str_body += $newline + $newline + "Please see attachment for detailed information on the Certification by Credit Type Hours test." + $newline + $newline + $newline

    # Put timestamp on the end of the email...
    $str_body += "<h5>Message generated on: " + $tempdate + ".</h5>"

    # Send the email...
    Send-MailMessage -smtpServer $smtpServer -to $emailToTestGroup -from $emailFrom -subject $envVar_subject -bodyashtml $str_body -attachments $envVar_attachment.FullName
}
Function EmailTestGroup6( $envVar_LMSversion, $envVar_success, $ReportsDir )
{
    $FileList = Join-Path -path $ReportsDir -childpath "*.html"
    $envVar_attachment = Get-ChildItem $FileList | where { -not $_.PsIsContainer } | sort LastWriteTime -descending | select -first 1

    $tempdate = get-date

    # Generate subject line
    if( $envVar_success -eq 0 ) { $envVar_subject = "P1 Regression Test (" + $tempdate + ") -- PASSED!!" } else { $envVar_subject = "P1 Regression Test (" + $tempdate + ") -- FAILED!!" }

    # Form email body...
    $str_body = ""
    $str_body += "P1 Regression test of $envVar_LMSVersion on the EXTERNAL environment has finished.  The P1 Regression test:" + $newline + $newline
    if( $envVar_success -eq 0 ) { $str_body += "<b><font size=12 color=GREEN>PASSED!!</font></b>" } else { $str_body += "<b><font size=12 color=RED>FAILED!!</font></b>" }
    $str_body += $newline + $newline + "Please see attachment for detailed information on the P1 Regression test." + $newline + $newline + $newline

    # Put timestamp on the end of the email...
    $str_body += "<h5>Message generated on: " + $tempdate + ".</h5>"

    # Send the email...
    Send-MailMessage -smtpServer $smtpServer -to $emailToTestGroup -from $emailFrom -subject $envVar_subject -bodyashtml $str_body -attachments $envVar_attachment.FullName
}
