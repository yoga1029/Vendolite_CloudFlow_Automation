pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                echo 'Code downloaded from GitHub'
            }
        }

        stage('Run Tests') {
            steps {
                bat 'dotnet test GIT_VMS-Phase1PortalAT.sln --filter "FullyQualifiedName~EndToEndFlow" --logger "trx"'
            }
        }

        stage('Publish Results') {
            steps {
                // allowEmptyResults avoids failure if file path slightly differs
                junit testResults: '**/*.trx', allowEmptyResults: true
            }
        }
    }

    post {
        success {
            emailext(
                to: 'subramanianyoga90@gmail.com',
                subject: "Automation Test Report - SUCCESS",
                mimeType: 'text/html',
                body: """
<table width="100%" cellpadding="0" cellspacing="0" style="border:1px solid #000;">
<tr>
<td style="background-color:#0b8a2a;color:white;padding:10px;font-size:18px;">
<b>BUILD SUCCESS</b>
</td>
</tr>

<tr>
<td style="padding:10px;">
<b>Project:</b> ${env.JOB_NAME}<br/>
<b>Build URL:</b> <a href="${env.BUILD_URL}">${env.BUILD_URL}</a><br/>
<b>Duration:</b> ${currentBuild.durationString}
</td>
</tr>

<tr>
<td style="background-color:#0b8a2a;color:white;padding:8px;">
<b>TEST RESULTS</b>
</td>
</tr>
<tr>
<td style="padding:10px;color:green;">
${TEST_COUNTS}
</td>
</tr>
</table>
"""
            )
        }

        failure {
            emailext(
                to: 'subramanianyoga90@gmail.com',
                subject: "Automation Test Report - FAILURE",
                mimeType: 'text/html',
                body: """
<table width="100%" cellpadding="0" cellspacing="0" style="border:1px solid #000;">
<tr>
<td style="background-color:#c0392b;color:white;padding:10px;font-size:18px;">
<b>BUILD FAILURE</b>
</td>
</tr>

<tr>
<td style="padding:10px;">
<b>Project:</b> ${env.JOB_NAME}<br/>
<b>Build URL:</b> <a href="${env.BUILD_URL}">${env.BUILD_URL}</a><br/>
<b>Duration:</b> ${currentBuild.durationString}
</td>
</tr>

<tr>
<td style="background-color:#c0392b;color:white;padding:8px;">
<b>TEST RESULTS</b>
</td>
</tr>
<tr>
<td style="padding:10px;color:red;">
${TEST_COUNTS}
</td>
</tr>
</table>
"""
            )
        }
    }
}
