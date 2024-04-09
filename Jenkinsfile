pipeline{
    agent any

    stages{
        
        stage('Get Source'){
            steps{
                git url: 'https://github.com/pessanitalo/Emprestimo.git', branch: 'main'
            }
        }


         stage('Docker Build'){
            steps{
                 script{
                    dockerapp = docker.build("italopessan/testeApi:${env.BUILD_ID}",
                    '-f Emprestimoapp/Dockerfile .')
                }
            }
        }

         stage('Docker Push Image'){
            steps{
               script{
                docker.withRegistry('https://registry.hub.docker.com', 'dockerhub')
                dockerapp.push('latest')
                }
            }
        }
    }
}