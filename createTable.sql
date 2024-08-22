DROP TABLE tbl_product;

CREATE TABLE tbl_product (
	id int NOT NULL AUTO_INCREMENT,
    product_name varchar(100) NOT NULL,
    product_description varchar(200) NOT NULL,
    product_price decimal(65,2) NOT NULL,
    PRIMARY KEY (id)
);

INSERT INTO tbl_product (product_name, product_description, product_price) VALUES ("Widget1","Just some product",15.50);
INSERT INTO tbl_product (product_name, product_description, product_price) VALUES ("Widget2","Just some product",20.35);
INSERT INTO tbl_product (product_name, product_description, product_price) VALUES ("Widget3","Just some product",12.25);
INSERT INTO tbl_product (product_name, product_description, product_price) VALUES ("Widget4","Just some product",5.25);

SELECT * FROM tbl_product WHERE id = 3;
