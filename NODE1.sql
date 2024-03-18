CREATE EXTENSION IF NOT EXISTS postgres_fdw;

DROP SCHEMA IF EXISTS sharding_schema CASCADE;
CREATE SCHEMA sharding_schema;
SET search_path = sharding_schema;


-- create master partitioned table
CREATE TABLE IF NOT EXISTS red_delta (
    r_id INT,
    r_name VARCHAR(100),
    d_name VARCHAR(100)
) PARTITION BY list (r_id);

CREATE TABLE red_delta_default 
   PARTITION OF red_delta DEFAULT;
   
-- create servers 
CREATE SERVER IF NOT EXISTS node2 FOREIGN DATA WRAPPER postgres_fdw
    OPTIONS (host 'postgres_node2', dbname 'shard2');

CREATE SERVER IF NOT EXISTS node3 FOREIGN DATA WRAPPER postgres_fdw
    OPTIONS (host 'postgres_node3', dbname 'shard3');
	
-- create user mappings
CREATE USER MAPPING IF NOT EXISTS FOR user1 SERVER node2
    OPTIONS (user 'user2', password 'password2');

CREATE USER MAPPING IF NOT EXISTS FOR user1 SERVER node3
    OPTIONS (user 'user3', password 'password3');


CREATE FOREIGN TABLE red_delta_first
    PARTITION OF red_delta
    FOR VALUES IN (0,1,2)
    SERVER node2;
	
CREATE FOREIGN TABLE red_delta_middle
    PARTITION OF red_delta
    FOR VALUES IN (3,4,5)
    SERVER node3;
	
CREATE FOREIGN TABLE red_delta_last
    PARTITION OF red_delta
    FOR VALUES IN (6,7,8,9,10)
    SERVER node2;
	
	
