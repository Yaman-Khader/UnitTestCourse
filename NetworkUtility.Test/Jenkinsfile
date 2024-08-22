pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                git url: 'https://github.com/Yaman-Khader/UnitTestCourse.git', branch: 'dev'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet restore'
                bat 'dotnet build'
            }
        }

        stage('Test') {
            steps {
                bat 'dotnet test --logger "trx;LogFileName=test_results.trx"'
                junit '**/TestResults/test_results.trx'
            }
        }

        stage('Deploy') {
            when {
                expression { currentBuild.result == null || currentBuild.result == 'SUCCESS' }
            }
            steps {
                echo 'Deploying to dev environment...'
                // Your deployment steps here
            }
        }
    }

    post {
        always {
            echo 'Pipeline completed.'
        }
    }
}
