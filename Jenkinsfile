pipeline {
    agent any

    environment {
        DOTNET_SOLUTION = 'GIT_VMS-Phase1PortalAT.sln'
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

                // Allow pipeline to continue even if tests fail
                catchError(buildResult: 'UNSTABLE', stageResult: 'UNSTABLE') {
                    bat "dotnet test ${env.DOTNET_SOLUTION} --logger \"trx;LogFileName=test_results.trx\""
                }
            }
        }
    }

    post {
        always {
            echo 'Publishing MSTest results to Jenkins'

            // Always publish results (pass or fail)
            mstest testResultsFile: '**/test_results.trx', keepLongStdio: true

            echo "Sending email with test counts"

            emailext(
                from: "${env.EMAIL_FROM}",
                subject: "Cloud Flow Automation Report - Build #${env.BUILD_NUMBER} - ${currentBuild.currentResult}",
                mimeType: 'text/html',
                body: '${SCRIPT, template="groovy-html.template"}',
                to: "${env.EMAIL_TO}",
                attachLog: false,
                presendScript: '''
                    def body = msg.getBody()

                    // remove CONSOLE OUTPUT section
                    body = body.replaceAll("(?s)CONSOLE OUTPUT.*", "")

                    // remove failed test name lines like: VMS_...(Age: 9)
                    body = body.replaceAll("VMS_.*\\(Age:.*?\\)", "")

                    msg.setContent(body, "text/html")
                '''
            )
        }
    }
}
