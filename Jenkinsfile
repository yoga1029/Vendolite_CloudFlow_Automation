pipeline {
    agent any

    environment {
        DOTNET_SOLUTION = 'GIT_VMS-Phase1PortalAT.sln'
        TEST_FILTER = 'FullyQualifiedName~EndToEndFlow'
        EMAIL_FROM = 'yogeswari@riota.in'
        EMAIL_TO = 'subramanianyoga90@gmail.com'
    }

    stages {
        stage('Checkout') {
            steps {
                echo 'Code downloaded from GitHub'
            }
        }

        stage('Run Tests') {
            steps {
                echo "Running MSTest tests on solution ${env.DOTNET_SOLUTION}"
                catchError(buildResult: 'FAILURE', stageResult: 'FAILURE') {
                    bat "dotnet test ${env.DOTNET_SOLUTION} --filter \"${env.TEST_FILTER}\" --logger \"trx;LogFileName=test_results.trx\""
                }
            }
        }

        stage('Publish Test Results') {
            steps {
                echo 'Publishing MSTest results to Jenkins'
                mstest testResultsFile: '**/test_results.trx', failOnError: false
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