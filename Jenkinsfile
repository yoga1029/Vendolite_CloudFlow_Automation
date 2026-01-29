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
                bat 'dotnet test GIT_VMS-Phase1PortalAT.sln --filter "FullyQualifiedName~EndToEndFlow"'
            }
        }
    }
 
    post {
        success {
            echo "EMAIL STEP REACHED - SUCCESS"
 
            emailext(
                subject: "Automation Test Report - SUCCESS",
                mimeType: 'text/html',
                body: '${SCRIPT, template="groovy-html.template"}',
                to: 'subramanianyoga90@gmail.com'
            )
        }

        failure {
            echo "EMAIL STEP REACHED - FAILURE"
 
            emailext(
                subject: "Automation Test Report - FAILURE",
                mimeType: 'text/html',
                body: '${SCRIPT, template="groovy-html.template"}',
                to: 'subramanianyoga90@gmail.com'
            )
        }
    }
}
