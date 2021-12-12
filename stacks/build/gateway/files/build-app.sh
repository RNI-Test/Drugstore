PHARMACY_API_URL=$1

cd app || exit
export API_HOST=${PHARMACY_API_URL}
envsubst < environment.ts.template > ./frontend/src/environments/environment.ts || exit
cd frontend || exit
npm run build --prod && \
cd dist && \
mv "$(find . -maxdepth 1 -type d | tail -n 1)" ./app     