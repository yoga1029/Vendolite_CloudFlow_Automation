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
        always {
            echo "EMAIL STEP REACHED"

            emailext(
    subject: "Automation Test Report - ${currentBuild.currentResult}",
    mimeType: 'text/html',
    body: '${SCRIPT, template="groovy-html.template"}',
    attachLog: true,
    attachmentsPattern: '**/extentreport.html',
    to: 'subramanianyoga90@gmail.com'
)

        }
    }
}
