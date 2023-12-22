CREATE TABLE items (
    id serial PRIMARY KEY,
    name varchar(50),
    price money CHECK (price > 0::money)
);