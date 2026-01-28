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
                bat 'dotnet test GIT_VMS-Phase1PortalAT.sln'
            }
        }
    }
}

post {
    always {
        emailext(
            subject: "Jenkins Job: ${env.JOB_NAME} - ${currentBuild.currentResult}",
            body: "Build Status: ${currentBuild.currentResult}\nJob: ${env.JOB_NAME}\nBuild Number: ${env.BUILD_NUMBER}",
            to: "yogasubra99@gmail.com"
        )
    }
}
