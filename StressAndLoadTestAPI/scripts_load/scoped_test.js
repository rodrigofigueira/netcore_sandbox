import http from 'k6/http';
import { sleep } from 'k6';

// Configurações do teste
export const options = {
    // Cenário de teste (simulando 100 usuários por 30 segundos)
    scenarios: {
        stress_test: {
            executor: 'constant-vus',
            vus: 100, // Número de usuários virtuais (requisições simultâneas)
            duration: '30s', // Duração do teste
        },
    },
    // Limites (thresholds) para falha do teste
    // Se o tempo médio de resposta for maior que 200ms, o teste falha.
    // Se a taxa de erros for maior que 1%, o teste falha.
    thresholds: {
        http_req_duration: ['avg<200'], // Tempo médio de resposta da requisição HTTP
        http_req_failed: ['rate<0.01'],  // Taxa de requisições com erro
    },
};

// Função principal do teste
export default function () {
    const url = 'https://localhost:7005/scoped'; // URL do endpoint a ser testado
    const payload = JSON.stringify({
        name: 'k6',
        test: 'load',
    });

    const params = {
        headers: {
            'Content-Type': 'application/json',
        },
    };

    http.post(url, payload, params);

    sleep(1);
}