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
