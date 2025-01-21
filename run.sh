docker build -t mtwmc/hahn-accessment1.0 . &&
docker run -tid -p 5094:5094 -p 5000:5000 -p 5173:5173 mtwmc/hahn-accessment1.0 