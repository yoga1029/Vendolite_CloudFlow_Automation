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
        catchError(buildResult: 'FAILURE', stageResult: 'FAILURE') {
            bat 'dotnet test GIT_VMS-Phase1PortalAT.sln --filter "FullyQualifiedName~EndToEndFlow" --logger "trx;LogFileName=testresults.trx"'
        }
        junit '**/*.trx'
    	}
}
    }
    post {
        success {
            echo "EMAIL STEP REACHED - SUCCESS"
            emailext(
		from: 'yogeswari@riota.in',
                subject: "Cloud Flow Automation Report v8.9.2 - Build #${env.BUILD_NUMBER} - ${currentBuild.currentResult}",
                mimeType: 'text/html',
                body: '${SCRIPT, template="groovy-html.template"}',
                to: 'subramanianyoga90@gmail.com',
		attachLog: false

            )
        }
 
        failure {
            echo "EMAIL STEP REACHED - FAILURE"
            emailext(
		from: 'yogeswari@riota.in',
                subject: "Cloud Flow Automation Report v8.9.2 - Build #${env.BUILD_NUMBER} - ${currentBuild.currentResult}",
                mimeType: 'text/html',
                body: '${SCRIPT, template="groovy-html.template"}',
                to: 'subramanianyoga90@gmail.com',
		attachLog: false
            )
        }
    }
}