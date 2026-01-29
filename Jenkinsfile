pipeline {
    agent any
    stages {
        stage('Checkout') {
            steps {
                echo 'Code downloaded from GitHub'
		git branch: 'master', url:'https://github.com/yoga1029/Vendolite_CloudFlow_Automation.git'
 
            }
        }
        stage('Run Tests') {
            steps {
                // Generate TRX test result file
                bat '''
                dotnet test GIT_VMS-Phase1PortalAT.sln --filter "FullyQualifiedName~EndToEndFlow" --logger "trx;LogFileName=testResults.trx"
                '''
            }
        }
 
        stage('Publish Test Results') {
            steps {
                // Jenkins reads TRX and calculates Passed/Failed
                junit '**/TestResults/*.trx'
            }
        }
    }
    post {
        success {
            echo "EMAIL STEP REACHED - SUCCESS"
            emailext(
                from: 'yogeswari@riota.in',
                subject: "Cloud Flow Automation Report v8.9.2 - Build #${BUILD_NUMBER} - SUCCESS",
                mimeType: 'text/html',
                body: '${SCRIPT, template="groovy-html.template"}',
                to: 'subramanianyoga90@gmail.com'
            )
        }
 
        failure {
            echo "EMAIL STEP REACHED - FAILURE"
            emailext(
                from: 'yogeswari@riota.in',
                subject: "Cloud Flow Automation Report v8.9.2 - Build #${BUILD_NUMBER} - FAILURE",
                mimeType: 'text/html',
                body: '${SCRIPT, template="groovy-html.template"}',
                to: 'subramanianyoga90@gmail.com'
            )
        }
    }
}